using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWLoan.Data;
using SWLoan.Models;

namespace SWLoan.Controllers
{
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private TimeSpan ts = new TimeSpan(23, 59, 59);

        public LoanController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 신청목록
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = _context)
            {
                var list = db.Loans.ToList().OrderByDescending(p => p.No);
                return View(list);
            }
        }

        public IActionResult Detail(int loanNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = _context)
            {
                var loan = db.Loans.FirstOrDefault(l => l.No.Equals(loanNo));
                return View(loan);
            }
        }

        /// <summary>
        /// 대출 신청
        /// </summary>
        /// <returns></returns>
        public IActionResult Submit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Submit(Loan model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            DateTime rd = (DateTime)model.RepaymentDate;

            model.LoanDate = DateTime.Now;
            model.RepaymentDate = rd.Date + ts;
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            model.UserName = _context.Users.FirstOrDefault(u => u.No.Equals(model.UserNo)).Name;
            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid)
            {
                using (var db = _context)
                {
                    db.Loans.Add(model);
                    if (db.SaveChanges() > 0)
                    {
                        return Redirect("List");
                    }
                }

            }
            ModelState.AddModelError(string.Empty, "신청을 저장할 수 없습니다.");
            return View(model);
        }

        /// <summary>
        /// 신청 삭제
        /// </summary>
        /// <param name="loanNo"></param>
        /// <returns></returns>
        public IActionResult Delete(int loanNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using (var db = _context)
            {
                var loan = db.Loans.FirstOrDefault(l => l.No.Equals(loanNo));
                db.Loans.Remove(loan);
                if (db.SaveChanges() > 0)
                {
                    return Redirect("List");
                }
            }
            ModelState.AddModelError(string.Empty, "신청이 삭제되지 않았습니다.");
            return Redirect("List");
        }
    }
}
