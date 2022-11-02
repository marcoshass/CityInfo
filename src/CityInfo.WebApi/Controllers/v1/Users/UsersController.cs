using CityInfo.Data.Commands.Users;
using CityInfo.Data.Queries.Users;
using CityInfo.Domain.Cqrs.Command;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using CityInfo.WebApi.Models.v1.Users;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1.Users
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IQueryHandlerAsync<GetUserByIdQuery, User> _getUserByIdQuery;
        private readonly ICommandHandlerAsync<RegisterUserCommand> _registerUserCommand;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IQueryHandlerAsync<GetUserByIdQuery, User> getUserByIdQuery,
            ICommandHandlerAsync<RegisterUserCommand> registerUserCommand,
            ILogger<UsersController> logger)
        {
            _getUserByIdQuery = getUserByIdQuery;
            _registerUserCommand = registerUserCommand;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id, CancellationToken cancelToken)
        {
            var user = await _getUserByIdQuery.Handle(new GetUserByIdQuery { Id = id }, cancelToken);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost()]
        public async Task<ActionResult<User>> CreateUser(CreateUserDto Input, CancellationToken cancelToken)
        {
            if (ModelState.IsValid)
            {
                var command = new RegisterUserCommand
                {
                    Email = Input.Email,
                    Password = Input.Password,
                    ConfirmPassword = Input.ConfirmPassword
                };

                await _registerUserCommand.Handle(command, cancelToken);

                if (command.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    //command.UserId
                    return Ok();
                }
            }

            return Problem();
        }
    }
}
