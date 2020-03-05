using System.Threading.Tasks;

namespace Infinity.Administration.Application.Base
{
    public interface IUseCase<in TUseCaseInput>
    {
        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        Task Execute(TUseCaseInput input);
    }
}
