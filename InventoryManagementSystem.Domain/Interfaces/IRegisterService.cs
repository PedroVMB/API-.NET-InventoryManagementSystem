using InventoryManagementSystem.Application.DTOs;
using InventoryManagementSystem.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface IRegisterService
    {
        Task<RegistrationResult> RegisterAdminAsync(RegisterModel model);
        Task<RegistrationResult> RegisterManagerAsync(RegisterModel model);
        Task<RegistrationResult> RegisterSellerAsync(RegisterModel model);
    }
}
