using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {

        public Name(string firstName , string lastName)
        {
            this.FirstName = firstName;
            LastName = lastName;

               AddNotifications( new ValidationContract()
                .Requires()
                .HasMinLen(FirstName,3,"FirstName","Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName,40,"FirstName","Nome deve conter pelo menos 3 caracteres")
               );
                
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public override string ToString(){
            return $"{FirstName} {LastName}";
        }

        
    }
}