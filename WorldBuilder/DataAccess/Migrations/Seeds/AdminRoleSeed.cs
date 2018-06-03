using DataAccess.Access;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Migrations.Seeds
{
    public static class AdminRoleSeed
    {
        public static void Run(WorldContext context)
        {
            try
            {
                if (context.Roles.Where(role => role.Name == "Admin").FirstOrDefault() == null)
                {
                    context.Roles.Add(
                        new IdentityRole
                        {
                            Name = "Admin"
                        });
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
            }
        }

    }
}
