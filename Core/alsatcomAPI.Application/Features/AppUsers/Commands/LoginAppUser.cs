using alsatcomAPI.Application.Absractions.Token;
using alsatcomAPI.Application.DTOs;
using alsatcomAPI.Application.Exceptions;
using alsatcomAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Features.AppUsers.Commands
{
    public class LoginAppUserCommandRequest : IRequest<LoginAppUserCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginAppUserCommandResponse
    {
    }
    //SUCCESS RESPONSE
    public class LoginAppUserSuccessCommandResponse : LoginAppUserCommandResponse
    {
        public Token Token { get; set; }
    }
    //ERROR RESPONSE
    public class LoginAppUserErrorCommandResponse : LoginAppUserCommandResponse
    {
        public string Message { get; set; }
    }

    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommandRequest, LoginAppUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly RoleManager<IdentityRole> _roleManager;

        public LoginAppUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _roleManager = roleManager;
        }

        public async Task<LoginAppUserCommandResponse> Handle(LoginAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            var roles = await _userManager.GetRolesAsync(appUser);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.Email, appUser.Email),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            if (appUser == null)
                appUser = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (appUser == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);

            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(5, claims);
                return new LoginAppUserSuccessCommandResponse()
                {
                    Token = token
                };
            }
            //return new LoginAppUserErrorCommandResponse() { 
            //        Message = "Kullanıcı adı veya şifre hatalı."
            //};
            throw new AuthenticationErrorException();
        }
    }
}
