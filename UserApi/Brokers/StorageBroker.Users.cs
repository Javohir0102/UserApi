using Microsoft.EntityFrameworkCore;
using UserApi.Models.User;

namespace UserApi.Brokers
{
    public partial class StorageBroker
    {
        DbSet<User> Users { get; set; }
        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public async ValueTask<IQueryable<User>> SelectAllUserAsync() =>
            SelectAllAsync<User>();

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(User user) =>
            await DeleteAsync(user);
    }
}
