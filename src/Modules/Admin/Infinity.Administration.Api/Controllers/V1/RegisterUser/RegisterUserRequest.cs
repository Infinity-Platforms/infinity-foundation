using Infinity.Administration.Application.Boundaries.RegisterNewUser;
using System.ComponentModel.DataAnnotations;

namespace Infinity.Administration.Api.Controllers.V1.RegisterUser
{
    public class RegisterUserRequest
    {
        [Required, MinLength(4)]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public RegisterUserInput ToUserInput()
        {
            return new RegisterUserInput {

                
                User =new Infrastructure.SqlServerDataAccess.Entities.User
                { 
                    Firstname=Firstname,
                    Lastname=Lastname,
                    Email=Email
                }
            };
        }
    }
}
