using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Application.Interfaces;
using LibraryManager.Domain;
using LibraryManager.Infrastructure.Persistence;
using LibraryManager.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        // GET: Members
        public ActionResult Index()
        {
            var vm = new MemberIndexVm();
            vm.Members = memberService.GetAllMembers();

            return View(vm);
        }

        // GET: Members/Details/5
        public ActionResult Details(int id)
        {
            var member = memberService.Get(id);

            var vm = new MemberDetailVm()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                SSN = member.SSN
            };
            return View(vm);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            var vm = new MemberCreateVm();
            return View(vm);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                //Skapa ny member
                var newMember = new Member();
                newMember.LastName = vm.LastName;
                newMember.FirstName = vm.FirstName;
                newMember.SSN = vm.SSN;

                memberService.Add(newMember);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home", "");
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}