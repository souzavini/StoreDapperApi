using System;
using Dapper.Shared.Commands;

namespace Dapper.Domain.StoreContext.Commands.CustomerCommands.Output
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}