using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using owinidentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace owinidentity.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User userm)
        {
            if(ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);

                var user = await userManager.FindAsync(userm.Name,userm.Password);
                if(user!=null)
                {
                    return View(userm);
                }
            
                user = new IdentityUser { UserName = userm.Name, Email = userm.Email };
                await userManager.CreateAsync(user,userm.Password);
            }
            return View(userm);
        }
    }
}