using InventoryManagementSystem.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResult> LoginAsync(Login model);
    }
}
