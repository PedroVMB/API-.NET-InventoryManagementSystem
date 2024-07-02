using InventoryManagementSystem.Application.DTOs;
using InventoryManagementSystem.Domain.Interfaces;
using InventoryManagementSystem.Domain.Models.User;
using InventoryManagementSystem.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public RegisterService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            JwtConfiguration jwtConfiguration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<RegistrationResult> RegisterAdminAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User already exists!"
                };
            }
            var user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Administrator))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Administrator));
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Administrator))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Administrator);
            }

            return new RegistrationResult
            {
                Success = true,
                Message = "User created successfully!"
            };
        }

        public async Task<RegistrationResult> RegisterManagerAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User already exists!"
                };
            }
            var user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Manager))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Manager);
            }

            return new RegistrationResult
            {
                Success = true,
                Message = "User created successfully!"
            };
        }

        public async Task<RegistrationResult> RegisterSellerAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User already exists!"
                };
            }
            var user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Seller))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Seller);
            }

            return new RegistrationResult
            {
                Success = true,
                Message = "User created successfully!"
            };
        }
    }
}
