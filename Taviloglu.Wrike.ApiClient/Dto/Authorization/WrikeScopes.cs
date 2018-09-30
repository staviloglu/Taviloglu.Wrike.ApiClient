namespace Taviloglu.Wrike.ApiClient.Dto.Authorization
{
    /// <summary>
    /// OAuth scopes allow you to specify exactly how your application needs to access Wrike data.
    /// </summary>
    public static class WrikeScopes
    {
        public const string Default = "Default";
        public const string wsReadOnly = "wsReadOnly";
        public const string wsReadWrite = "wsReadWrite";
        public const string amReadOnlyUser = "amReadOnlyUser";
        public const string amReadWriteUser = "amReadWriteUser";
        public const string amReadOnlyGroup = "amReadOnlyGroup";
        public const string amReadWriteGroup = "amReadWriteGroup";
        public const string amReadOnlyInvitation = "amReadOnlyInvitation";
        public const string amReadWriteInvitation = "amReadWriteInvitation";
        public const string amReadOnlyWorkflow = "amReadOnlyWorkflow";
        public const string amReadWriteWorkflow = "amReadWriteWorkflow";
        public const string amReadOnlyTimelogCategory = "amReadOnlyTimelogCategory";
        public const string amReadWriteTimelogCategory = "amReadWriteTimelogCategory";

    }
}
