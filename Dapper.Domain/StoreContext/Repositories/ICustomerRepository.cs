using System;
using System.Collections.Generic;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Queries;

namespace Dapper.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);

         void Save(Customer customer);

         IEnumerable<ListCustomerQueryResult> Get();

         IEnumerable<GetCustomerQueryResult> GetByid(Guid id);

         

         
    }
}