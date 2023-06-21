using alsatcomAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.AppUsers.Commands
{
    public class CreateAppUserCommandRequest : IRequest<CreateAppUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }

    public class CreateAppUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public CreateAppUserCommandHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.Username,
                Email = request.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            CreateAppUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(Configuration.GetRole("User"));

                if (!roleExists)
                {
                    IdentityRole role = new IdentityRole(Configuration.GetRole("User"));
                    role.NormalizedName = Configuration.GetRole("User");

                    _roleManager.CreateAsync(role).Wait();
                }

                //Kullanıcıya ilgili rol ataması yapılır.
                _userManager.AddToRoleAsync(user, Configuration.GetRole("User")).Wait();

                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            }
            else
            {
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";
            }

            return response;
        }
    }
}
