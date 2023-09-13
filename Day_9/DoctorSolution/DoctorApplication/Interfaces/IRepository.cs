namespace DoctorApplication.Interfaces
{
    public interface IRepository<K, T>
    {
        public T Create(T entity);
        public T Delete(K key);
        public T Get(K key);

        public T Update(T entity);
        public ICollection<T> GetAll();
        object? Get(object id);
    }
}
