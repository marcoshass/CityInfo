using CityInfo.Data.Commands.Users;
using CityInfo.Data.Queries.Users;
using CityInfo.Domain.Cqrs.Command;
using CityInfo.Domain.Cqrs.Query;
using CityInfo.Domain.Entities;
using CityInfo.WebApi.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.WebApi.Controllers.v1.Users
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IQueryHandlerAsync<GetUserByIdQuery, User> _getUserByIdQuery;
        private readonly ICommandHandlerAsync<CreateUserCommand> _createUserCommand;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IQueryHandlerAsync<GetUserByIdQuery, User> getUserByIdQuery,
            ICommandHandlerAsync<CreateUserCommand> registerUserCommand,
            ILogger<UsersController> logger)
        {
            _getUserByIdQuery = getUserByIdQuery;
            _createUserCommand = registerUserCommand;
            _logger = logger;
        }

        // GET api/v1/users/guid

        [HttpGet("{id}", Name = nameof(GetUser))]
        public async Task<ActionResult<User>> GetUser(string id, CancellationToken cancelToken)
        {
            var user = await _getUserByIdQuery.Handle(new GetUserByIdQuery { Id = id }, cancelToken);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/v1/users

        [HttpPost()]
        public async Task<ActionResult<User>> CreateUser(AddUserRequest Input,
            CancellationToken cancelToken)
        {
            var command = new CreateUserCommand
            {
                Email = Input.Email,
                Password = Input.Password,
                ConfirmPassword = Input.ConfirmPassword
            };

            await _createUserCommand.Handle(command, cancelToken);
            if (command.Succeeded)
            {
                return CreatedAtRoute(nameof(GetUser),
                    new
                    {
                        id = command.UserId,
                        cancelToken = default(CancellationToken)
                    }, command
                );
            }

            return BadRequest(command.Errors);
        }
    }
}
