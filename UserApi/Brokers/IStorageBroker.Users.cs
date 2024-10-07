using UserApi.Models.User;

namespace UserApi.Brokers
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);

        ValueTask<IQueryable<User>> SelectAllUserAsync();
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}
