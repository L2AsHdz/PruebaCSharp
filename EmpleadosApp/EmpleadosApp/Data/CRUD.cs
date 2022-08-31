namespace EmpleadosApp.Data
{
    public interface CRUD<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        T Read(T obj);
        List<T> ReadAll();
    }
}
