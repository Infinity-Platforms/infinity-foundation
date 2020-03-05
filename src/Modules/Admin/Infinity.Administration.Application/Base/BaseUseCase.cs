using Microsoft.Extensions.Logging;

namespace Infinity.Administration.Application.Base
{
    public class BaseUseCase<TUseCase>
    {
        protected readonly ILogger<TUseCase> _logger;

        public BaseUseCase(ILogger<TUseCase> logger)
        {
            _logger = logger;
        }
    }
}
