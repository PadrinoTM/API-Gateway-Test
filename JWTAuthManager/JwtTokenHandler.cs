using JWTAuthManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "Some23Undisputable6JWTinthis2022Projectsfrom";
        public const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccounts> _userAccounts;
        public JwtTokenHandler()
        {
            _userAccounts = new List<UserAccounts>
            {
                new UserAccounts{ UserName = "Admin", Password = "admin123", Role = "Administrator"},
                new UserAccounts{ UserName = "User1", Password = "user123", Role = "Teacher"},
                new UserAccounts{ UserName = "User2", Password = "user234", Role = "Student"},

            };
        }
        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authReq)
        {
            if (string.IsNullOrWhiteSpace(authReq.Username) || string.IsNullOrWhiteSpace(authReq.Password))
                return null;

            var userAccount = _userAccounts.Where(x => x.UserName == authReq.Username && x.Password == authReq.Password).FirstOrDefault();
            if (userAccount == null) return null;

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenkey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authReq.Username),
                new Claim("Role", userAccount.Role)


            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenkey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenhandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenhandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenhandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpriresInSeconds = ((int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds).ToString() + " seconds",
                JwtToken = token,
            };

        }

    }
}


   

