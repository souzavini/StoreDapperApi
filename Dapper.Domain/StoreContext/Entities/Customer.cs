using System.Collections.Generic;
using System.Linq;
using Dapper.Domain.StoreContext.ValueObjects;
using FluentValidator;

namespace Dapper.Domain.StoreContext.Entities
{
    public class Customer : Notifiable
    {
        private readonly IList<Adress> _addresses;
        //SOLID
        public Customer(Name Name,
        Document document,
        Email email,
        string phone
        )
        {
            Document = document;
            Email = email;
            Phone = phone;
        }

        public Customer(Name name) 
        {
            this.Name = name;
               
        }
        public Name Name { get; private set; }
        public Document Document { get;private  set; }
        public Email Email { get;private  set; }
        public string Phone { get;private  set; }

       public IReadOnlyCollection<Adress> Address { get{ return _addresses.ToArray();}}
        
        public void AddAdress (Adress address){
                _addresses.Add(address);
        }
    }


}