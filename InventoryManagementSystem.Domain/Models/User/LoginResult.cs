using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Models.User
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Error { get; set; }
    }
}
