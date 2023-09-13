namespace BloggingPlatformApplication.Interfaces
{
    public interface IAddingEntity<T>
    {
        public T Add(T entity);
    }
}