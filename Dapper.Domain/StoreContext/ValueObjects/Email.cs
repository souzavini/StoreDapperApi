using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications( new ValidationContract()
                .Requires()
                .IsEmail(Address,"Email", "O Email é invalido")
               );


        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}