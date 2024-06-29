using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infrastructure.Auth
{
    public class UserRoles
    {
        /// <summary>
        /// //O Administrador é responsável pela configuração geral do sistema e gerenciamento de usuários. Eles têm o nível mais alto de acesso.
        /// </summary>
        public const string Administrator = "Administrator";

        /// <summary>
        /// O Gerente supervisiona as operações diárias e é responsável pela gestão de equipe e relatórios.
        /// </summary>
        public const string Manager = "Manager";

        /// <summary>
        /// O Vendedor está na linha de frente e é responsável por vender produtos e interagir com os clientes.
        /// </summary>
        public const string Seller = "Seller"; //Vendedor 
    }
}
