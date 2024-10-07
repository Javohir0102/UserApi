using UserApi.Models.User;

namespace UserApi.Services.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        ValueTask<IQueryable<User>> RetvieveAllUserAsync();
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}