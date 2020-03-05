namespace Infinity.Administration.Application.UseCases
{
    using Infinity.Administration.Application.Base;
    using Infinity.Administration.Application.Boundaries.UserDetails;
    using Infinity.Administration.Application.Globalization;
    using Infinity.Administration.Domain.Users;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="GetUserDetailsUseCase" />
    /// </summary>
    public class GetUserDetailsUseCase : BaseUseCase<GetUserDetailsUseCase>, IUseCase
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
        /// Initializes a new instance of the <see cref="GetUserDetailsUseCase"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{GetUserDetailsUseCase}"/></param>
        /// <param name="outputPort">The outputPort<see cref="IOutputPort"/></param>
        /// <param name="userRepository">The userRepository<see cref="IUserRepository"/></param>
        public GetUserDetailsUseCase(ILogger<GetUserDetailsUseCase> logger, IOutputPort outputPort, IUserRepository userRepository)
            :base(logger)
        {
            _outputPort = outputPort;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Executes Get User Detail Use Case
        /// </summary>
        /// <param name="input">The input<see cref="RegisterUserInput"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Execute(UserDetailsInput input)
        {
            if (input is null)
            {
                _outputPort.WriteError(Messages.InputIsNull);
                _logger.LogInformation(Messages.InputIsNull);
                return;
            }
            else if (input.Id<=0)
            {
                var message = string.Format(Messages.InvalidInputFor , Messages.UserId);
                _outputPort.WriteError(message);
                _logger.LogInformation(message);
                return;
            }

            _logger.LogInformation("Validation ok, retrieving user detail..");

            var result = await _userRepository.GetById(input.Id);

            if (result ==null)
            {
                _logger.LogInformation(Messages.CouldNotFindResult);
                _outputPort.NotFound(Messages.CouldNotFindResult);

                return;
            }

            var output = new UserDetailsOutput
            {
                User=(User) result
            };

            this._outputPort.Standard(output);
        }

    }
}
