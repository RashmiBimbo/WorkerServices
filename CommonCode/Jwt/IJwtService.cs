using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCode.Models.Dtos;
using CommonCode.Models.Dtos.Identity;

namespace CommonCode.Jwt
{
    public interface IJwtService
    {
        public AuthResponseDto CreateJwtToken(AppUserDto user);
    }
}
