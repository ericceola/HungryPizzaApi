using FluentValidation;
using HungryPizza.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.Domain.Validator
{
    public class CustomerOrderRequestValidator : AbstractValidator<CustomerOrderRequest>
    { 
        public CustomerOrderRequestValidator()
        {

            When(customer => !customer.CustomerId.HasValue || customer.CustomerId == 0, () =>
            {
                RuleFor(customer => customer.Street).NotEmpty().WithMessage("Informe o nome da rua.");
                RuleFor(customer => customer.Number).NotEmpty().WithMessage("Informe o número da residência.");
                RuleFor(customer => customer.District).NotEmpty().WithMessage("Informe o bairro.");
                RuleFor(customer => customer.City).NotEmpty().WithMessage("Informe a cidade.");
                RuleFor(customer => customer.RegionState).NotEmpty().WithMessage("Informe o Uf.");
                RuleFor(customer => customer.ZipCode).NotEmpty().WithMessage("Informe o cep.");
                RuleFor(customer => customer.ContactPhone).NotEmpty().WithMessage("Informe um telefone para contato.");

            });
            
            RuleForEach(x => x.OrderItens).NotEmpty().WithMessage("Informe pelo menos uma pizza");

            RuleFor(x => x.OrderItens).Custom((list, context) => {
                if (list.Where(p => p.ProductId == 0).Count() > 0)
                {
                    context.AddFailure("Informe uma pizza.");
                }
            });


            RuleFor(x => x.OrderItens).Custom((list, context) => {
            if (list.Where(p => p.Quantity == 0).Count() > 0)
                {
                    context.AddFailure("Informe a quantidade da pizza.");
                }
            });

            RuleFor(x => x.OrderItens).Custom((list, context) => {
                if (list.Sum(x => x.Quantity) > 10)
                {
                    context.AddFailure("Excedeu o limite máximo de pizza do mesmo sabor. (Limite por sabor 10)");
                }
            });

            //RuleFor(x => x.OrderItens).Custom((list, context) => {
            //    if (list.Where(p => p.Quantity > 10).Count() > 0)
            //    {
            //        context.AddFailure("Excedeu o limite máximo de pizza do mesmo sabor. (Limite por sabor 10)");
            //    }
            //});

           
          
        }
    }
}
