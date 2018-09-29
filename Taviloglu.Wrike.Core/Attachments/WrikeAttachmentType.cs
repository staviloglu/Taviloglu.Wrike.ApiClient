namespace Taviloglu.Wrike.Core.Attachments
{
    public enum WrikeAttachmentType
    {
        /// <summary>
        /// Attachment file content stored in Wrike. When deleted, actual file is removed
        /// </summary>
        Wrike,
        /// <summary>
        /// Google attachment. Attachment can be accessed only via URL, downloads are not supported by Wrike.When deleted, only stored link is removed
        /// </summary>
        Google,
        /// <summary>
        /// DropBox attachment. When deleted, only stored link is removed
        /// </summary>
        DropBox,

        /// <summary>
        /// Box attachment. Attachment can be accessed only via URL, downloads are not supported by Wrike.When deleted, only stored link is removed
        /// </summary>
        Box,

        /// <summary>
        /// OneDrive attachment. When deleted, only stored link is removed
        /// </summary>
        OneDrive,

        /// <summary>
        /// External attachment
        /// </summary>
        External

    }
}
