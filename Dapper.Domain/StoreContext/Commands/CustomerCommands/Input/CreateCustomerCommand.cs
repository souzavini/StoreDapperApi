using Dapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get;  set; }


        public bool Valid()
        {
             AddNotifications( new ValidationContract()
                .Requires()
                .HasMinLen(FirstName,3,"FirstName","Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName,40,"FirstName","Nome deve conter pelo menos 3 caracteres")
               );
            return IsValid;
        }

        //Se o usuario existe no banco  e CPF existe no banco 


    }
}