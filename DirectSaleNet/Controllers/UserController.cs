using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectSaleNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectSaleNet.Controllers
{
    public class UserController : Controller
    {
        private readonly Models.DirectSaleContext _context;
        public UserController(Models.DirectSaleContext context)
        {
            _context = context;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_context.User.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            return View(_context.User.Find(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                User user = new User();
                user.UserId = collection["UserID"];
                user.Pwd = collection["Pwd"];
                user.UserName = collection["UserName"];
                user.NickName = collection["NickName"];
                user.ManufactorId = int.Parse(collection["ManufactorId"]);

                //然后把商品添加到商品集合中去
                _context.User.Add(user);

                //保存到数据库
                _context.SaveChanges();  //自动生成insert 语句

                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_context.User.Find(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                User user = _context.User.Find(id);
                user.UserId = collection["UserID"];
                user.Pwd = collection["Pwd"];
                user.UserName = collection["UserName"];
                user.NickName = collection["NickName"];
                user.ManufactorId = int.Parse(collection["ManufactorId"]);

                // TODO: Add update logic here
                _context.SaveChanges();  //自动生成insert 语句
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_context.User.Find(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                User user = _context.User.Find(id);
                if(user != null)
                {
                    _context.User.Remove(user);  //标识这个数据要被删除 在数据库中还未删除
                    _context.SaveChanges();
                }
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