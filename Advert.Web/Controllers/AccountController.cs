using Advert.Web.Models.Accounts;
using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime.Internal.Transform;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advert.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<CognitoUser> _signInManager;
        private readonly UserManager<CognitoUser> _userManager;
        private readonly CognitoUserPool _pool;

        public AccountController(SignInManager<CognitoUser> signInManager, UserManager<CognitoUser> userManager, CognitoUserPool pool)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _pool = pool;
        }
        [HttpGet]
        public async Task<IActionResult> signup()
        {
            var model = new signup();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> signup(signup Model)
        {
            if (ModelState.IsValid)
            {
                var user = _pool.GetUser(Model.Email);
                if (user.Status != null)
                {
                    ModelState.AddModelError("UserExist", $"User with {Model} already exist");
                    return View(Model);
                    
                }
                //user.Attributes.Add(CognitoAttribute.Name, Model.Email);
                var createdUser = await _userManager.CreateAsync(user, Model.Password).ConfigureAwait(false);
                if (createdUser.Succeeded)
                {
                    return RedirectToAction(nameof(changePassword));
                }
            }
            return View();
        }
        public async Task<IActionResult> changePassword()
        {
            return View();
        }
    }
}
