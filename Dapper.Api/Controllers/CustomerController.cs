using System;
using System.Collections.Generic;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Input;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Output;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Handlers;
using Dapper.Domain.StoreContext.Queries;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        [ResponseCache(Duration=60)]
        public IEnumerable<ListCustomerQueryResult> Get(){
            return _repository.Get();
        }

        [HttpGet]
        [Route("customer/{id}")]
        public IEnumerable<GetCustomerQueryResult> GetById(Guid id){
            return _repository.GetByid(id);
        }

        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command){
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("customer/{id}")]
        public Customer Put([FromBody]Customer customer){
            return null;
        }

        [HttpDelete]
        [Route("customer/{id}")]
        public string Delete(){
            return "hello world";
        }
    }
}