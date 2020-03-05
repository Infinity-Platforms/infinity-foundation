using Infinity.Administration.Application.Base;

namespace Infinity.Administration.Application.Boundaries.RegisterNewUser
{
    public class RegisterUserOutput: BaseUseCaseOutput
    {
        public int Id { get; set; }
        public string Guid { get; set; }

        public string Name { get; set; }
    }
}
