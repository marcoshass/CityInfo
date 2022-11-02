using CityInfo.Data.Model;
using CityInfo.Domain.Cqrs.Command;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Data.Commands.Users
{
    public class RegisterUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Succeeded { get; set; }
        public string UserId { get; set; }
    }

    public class RegisterUserCommandHandler : ICommandHandlerAsync<RegisterUserCommand>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public RegisterUserCommandHandler(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
        }

        public async Task Handle(RegisterUserCommand command, CancellationToken cancelToken = default(CancellationToken))
        {
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, command.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, command.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, command.Password);

            if (result.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                command.Succeeded = result.Succeeded;
                command.UserId = userId;
            }
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has " +
                    $"a parameterless constructor");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("A user store with email support is required.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
