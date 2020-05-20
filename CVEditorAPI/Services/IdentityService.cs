using CVEditorAPI.Configurations;
using CVEditorAPI.Data;
using CVEditorAPI.Data.Dtos.Responses;
using CVEditorAPI.Data.Model;
using CVEditorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CVEditorAPI.Services
{
    public class IdentityService: Service<User>, IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(UserManager<User> userManager, DataContext context, JwtSettings jwtSettings)
            :base(context)
        {
            this._jwtSettings = jwtSettings;
            this._userManager = userManager;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await this._userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User dosen't exist" }
                };
            }

            var userHasValidPassword = await this._userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User/pasword combination is wrong"}
                };
            }

            return this.GenerateAuthenticationResult(user);

        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var existingUser = await this._userManager.FindByEmailAsync(email);

            if(existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exists" }
                };
            }

            var newUser = new User()
            {
                Email = email,
                UserName = email
            };

            var createdUser = await this._userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResult(newUser);
        }

        private AuthenticationResult GenerateAuthenticationResult(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: user.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: JwtRegisteredClaimNames.Email, value: user.Email),
                    new Claim(type: "id", value: user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                IsSuccess = true,
                UserId = user.Id,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
