using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Clients.Extensions;
using RESTFulSense.Controllers;
using UserApi.Models.User;
using UserApi.Services.Users;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RESTFulController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
        {
            User addedUser = await userService.AddUserAsync(user);

            return Ok(addedUser);
        }

        [HttpGet]
        public async ValueTask<ActionResult<IQueryable<User>>> GetAllUserAsync()
        {
            IQueryable<User> users = await this.userService.RetvieveAllUserAsync();

            return Ok(users);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(User user)
        {
            try
            {
                User updatedUser = await userService.UpdateUserAsync(user);

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
             //return Ok(await userService.UpdateUserAsync(user));
        }

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUserAsync(User user)
        {
            var deletedUser = await userService.DeleteUserAsync(user);

            return Ok(deletedUser);
        }
    }
}
