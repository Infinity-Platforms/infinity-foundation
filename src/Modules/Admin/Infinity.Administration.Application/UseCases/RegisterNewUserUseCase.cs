namespace Infinity.Administration.Application.UseCases
{
    using Infinity.Administration.Application.Base;
    using Infinity.Administration.Application.Boundaries.RegisterNewUser;
    using Infinity.Administration.Application.Globalization;
    using Infinity.Administration.Domain.Users;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="RegisterNewUserUseCase" />
    /// </summary>
    public class RegisterNewUserUseCase : BaseUseCase<RegisterNewUserUseCase>, IUseCase
    {
        /// <summary>
        /// Defines the _outputPort
        /// </summary>
        private readonly IOutputPort _outputPort;

        /// <summary>
        /// Defines the _userRepository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewUserUseCase"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{RegisterNewUserUseCase}"/></param>
        /// <param name="outputPort">The outputPort<see cref="IOutputPort"/></param>
        /// <param name="userRepository">The userRepository<see cref="IUserRepository"/></param>
        public RegisterNewUserUseCase(
                ILogger<RegisterNewUserUseCase> logger,
                IOutputPort outputPort,
                IUserRepository userRepository
            ) : base(logger)
        {
            _outputPort = outputPort;
            _userRepository = userRepository;
        }

        /// <summary>
        /// The Execute
        /// </summary>
        /// <param name="input">The input<see cref="RegisterUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Execute(RegisterUserInput input)
        {
            if (input is null)
            {
                _outputPort.WriteError(Messages.InputIsNull);
                _logger.LogInformation("Input is null");
                return;
            }


            _logger.LogInformation("Validation ok, Registering new user detail..");

            input.User.Guid = Guid.NewGuid().ToString();

            await _userRepository.Insert(input.User);

            var lastInsertedId = 1;

            if (lastInsertedId <= 0)
            {
                _logger.LogInformation(Messages.CouldNotRegister);
                this._outputPort.NotFound(Messages.CouldNotRegister);

                return;
            }

            var output = new RegisterUserOutput
            {
                Id = lastInsertedId
            };

            _outputPort.Standard(output);
        }
    }
}
