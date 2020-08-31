using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWLoan.Data;
using SWLoan.Models;
using SWLoan.ViewModels;

namespace SWLoan.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = _context)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id.Equals(model.Id) && u.Password.Equals(model.Password));

                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.No);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel, User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = _context)
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
