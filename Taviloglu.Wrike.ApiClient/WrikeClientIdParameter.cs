using System;

namespace Taviloglu.Wrike.ApiClient
{
    /// <summary>
    /// 
    /// </summary>
    public struct WrikeClientIdParameter
    {
        private readonly string _id;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public WrikeClientIdParameter(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (id.Trim() == string.Empty)
            {
                throw new ArgumentException($"value can not be empty string", nameof(id));
            }

            _id = id;
        }

        /// <summary>
        /// Returns the id value as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(WrikeClientIdParameter id)
        {
            return id.ToString();
        }

        public static implicit operator WrikeClientIdParameter(string id)
        {
            return new WrikeClientIdParameter(id);
        }

        /// <summary>
        /// Given Id
        /// </summary>
        public string Value
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_id))
                {
                    throw new ArgumentNullException("id");
                }

                return _id;
            }
        }
    }
}
