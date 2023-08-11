namespace FileCabinetAppOOP.Caching
{
    public interface ICacheManager
    {
        void Add<T>(string key, T value, TimeSpan expirationTime);
        List<T>? Get<T>(string key) where T : class;
        List<T> GetAll<T>() where T : class;
        void Remove(string key);
    }
}
