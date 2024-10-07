using UserApi.Brokers;
using UserApi.Models.User;

namespace UserApi.Services.Users
{
    public class UserService : IUserService
    {
        private IStorageBroker storageBroker;
        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<User> AddUserAsync(User user)
        {
            return await this.storageBroker.InsertUserAsync(user);
        }

        public async ValueTask<IQueryable<User>> RetvieveAllUserAsync()
        {
            return await this.storageBroker.SelectAllUserAsync();
        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            return await this.storageBroker.UpdateUserAsync(user);
        }
        public async ValueTask<User> DeleteUserAsync(User user)
        {
            return await this.storageBroker.DeleteUserAsync(user);
        }
    }
}
