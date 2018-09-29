using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Taviloglu.Wrike.Core.Attachments;

namespace Taviloglu.Wrike.Core.Json
{
    internal class WrikeAttachmentConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WrikeAttachment);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            JToken token;

            bool isFolderAttachment = jObject.TryGetValue("folderId", out token) && token.Type == JTokenType.String;
            if (isFolderAttachment)
            {
                return jObject.ToObject<WrikeFolderAttachment>();
            }
            else
            {
                return jObject.ToObject<WrikeTaskAttachment>();
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
