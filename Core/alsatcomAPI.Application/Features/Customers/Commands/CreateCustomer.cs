﻿using alsatcomAPI.Application.Repositories;
using alsatcomAPI.Application.Utilities.Results;
using alsatcomAPI.Application.Utilities.Results.SuccessResults;
using alsatcomAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.Customers.Commands
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class CreateCustomerCommandResponse : Result
    {
        public CreateCustomerCommandResponse(bool success) : base(success)
        {
        }

        public CreateCustomerCommandResponse(bool success, string message) : base(success, message)
        {
        }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customer customer = new() { Name = request.Name, Email = request.Email };
            await _customerWriteRepository.AddAsync(customer);
            await _customerWriteRepository.SaveAsync();

            return new CreateCustomerCommandResponse(true, "Successful");
        }
    }
}
