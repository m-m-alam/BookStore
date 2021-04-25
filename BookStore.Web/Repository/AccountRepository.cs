using BookStore.Web.Entity;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        
        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task CreateUserAsync(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB
            };
             await _userManager.CreateAsync(user, model.Password);
            //return result;
        }

        public async Task<bool> Login(LoginModel model)
        {
            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            var user = await _userManager.FindByEmailAsync(model.Email);
            var isValidUser = await _userManager.CheckPasswordAsync(user, model.Password);

            return isValidUser;

        }

        
    }
}
