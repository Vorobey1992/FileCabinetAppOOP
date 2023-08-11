namespace FileCabinetAppOOP.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CacheExpirationAttribute : Attribute
    {
        public int ExpirationTime { get; set; } // Cache expiration time in minutes
    }
}
