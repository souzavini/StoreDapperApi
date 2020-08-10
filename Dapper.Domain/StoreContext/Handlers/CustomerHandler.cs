using System;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Input;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Output;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Domain.StoreContext.Services;
using Dapper.Domain.StoreContext.ValueObjects;
using Dapper.Shared.Commands;
using FluentValidator;

namespace Dapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, 
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAdressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository,IEmailService emailService)
        {
              _repository =   repository;
              _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verifica se CPF ja existe 
                if(_repository.CheckDocument(command.Document)){
                    AddNotification("Document","Este CPF já está em uso");
                }
            //Verifica se o email existe 
                  if(_repository.CheckEmail(command.Document)){
                    AddNotification("Document","Este Email já está em uso");
                }   

               
            // criar VOs
            var name = new Name(command.FirstName,command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);


            // Criar entidade
            var customer = new Customer(name,document,email,command.Phone);
            
            //validar entidades 
            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

             if(Invalid){
                    return new CreateCustomerCommandResult(false,"Ops, corrija o cadastro",Notifications);
                }

                //Persistir Cliente
                _repository.Save(customer);

                //Enviar Email de boas vindas
                _emailService.Send(email.Address,"Hello@balta.io","Bem vindo","Seja bem vindo ao Balta Store!");

                // Retornar o resultado para tela
            return new CreateCustomerCommandResult(true,"Bem vindo ao cadastro",new{
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}