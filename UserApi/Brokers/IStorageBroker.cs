using UserApi.Models.User;

namespace UserApi.Brokers
{
    public partial interface IStorageBroker
    {
        ValueTask<T> InsertAsync<T>(T entity) where T : class;
        IQueryable<T> SelectAllAsync<T>() where T : class;  
        ValueTask<T> UpdateAsync<T>(T entity) where T : class;
        ValueTask<T> DeleteAsync<T>(T entity) where T : class;
    }
}