using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ORMDataManager.Library.DataAccess;
using ORMDataManager.Library.Models;
using ORMDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ORMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("api/User/Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();

            using (var context = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var users = userManager.Users.ToList();
                var roles = context.Roles.ToList();

                //output = users.Select(u => new ApplicationUserModel
                //{
                //    Id = u.Id,
                //    Email = u.Email,
                //    Roles = u.Roles.Join(roles,
                //                            s1 => s1.RoleId,
                //                            s2 => s2.Id,
                //                            (s1, s2) => new { a = s1, b = s2 }).ToDictionary(x => x.a.RoleId, x => x.b.Name)
                //}).ToList();

                foreach (var user in users)
                {
                    ApplicationUserModel u = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                    };

                    foreach (var role in user.Roles)
                    {
                        u.Roles.Add(role.RoleId, roles.Where(x => x.Id == role.RoleId).First().Name);
                    }

                    output.Add(u);
                }
            }
            return output;
        }
    }
}
