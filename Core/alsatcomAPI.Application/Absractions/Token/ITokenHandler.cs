using alsatcomAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application.Absractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
