using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Infra.StoreContext.DataContext;
using System.Data;
using Dapper;
using MySqlConnector;
using System.Linq;
using System.Collections.Generic;
using Dapper.Domain.StoreContext.Queries;
using System;

namespace Dapper.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext Context)
        {
            _context = Context;
        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.Query("soducomrer", new { Document = document }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault(); }

        public bool CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context.Connection.Query<ListCustomerQueryResult>(
                "Select id, FirstName,Document, Email FROM Customer"
            );
        }

        public IEnumerable<GetCustomerQueryResult> GetByid(Guid id)
        {
            return _context.Connection.Query<GetCustomerQueryResult>(
                "Select id, FirstName,Document, Email FROM Customer WHERE Id=@id",new{id=id}
            );
        }

        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }

    }
