using Microsoft.AspNet.Identity.EntityFramework;
using Potatotech.GestaoRestaurante.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potatotech.GestaoRestaurante.Dominio.DataAccess
{
    public class UserContext : IdentityDbContext<User>
    {

    }
}
