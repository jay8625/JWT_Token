﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Authentification
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IDictionary<string, string> user = new Dictionary<string, string>
        { { "test1", "password1" }, { "test2", "password2" } };
        private readonly string key;
        public AuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            if (!user.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey=Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes .Name, username),
                }),
                Expires=DateTime.Now.AddHours(1),
                SigningCredentials=     
                new SigningCredentials(new SymmetricSecurityKey(tokenkey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token=tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}