namespace Taviloglu.Wrike.Core.Users
{
    public enum WrikeUserType
    {
        /// <summary>
        /// Person
        /// </summary>
        Person,
        /// <summary>
        /// Group of users. Group userId can be used in folder/task sharing requests only. It has no effect in other operations
        /// </summary>
        Group
    }
}
