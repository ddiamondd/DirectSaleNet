using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectSaleNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectSaleNet.Controllers
{
    public class ManufactorController : Controller
    {
        private readonly Models.DirectSaleContext _context;
        public ManufactorController(Models.DirectSaleContext context)
        {
            _context = context;
        }


        // GET: Manufactor
        public ActionResult Index()
        {
            return View(_context.Manufactor.ToList());
        }

        // GET: Manufactor/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Manufactor.Find(id));
        }

        // GET: Manufactor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufactor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Manufactor manufactor = new Manufactor();

                manufactor.Id = int.Parse(collection["Id"]);
                manufactor.CompanyName = collection["CompanyName"];
                manufactor.Address = collection["Address"];
                manufactor.Province = collection["Province"];
                manufactor.City = collection["City"];
                manufactor.ContactTel = collection["ContactTel"];
                manufactor.RegistDate = DateTime.Parse(collection["RegistDate"]);
                manufactor.Status = collection["Status"];
                //数据库里面的数据类型是char 但是Models里面的数据类型是String

                _context.Manufactor.Add(manufactor);

                //保存到数据库
                _context.SaveChanges();  //自动生成insert 语句

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufactor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Manufactor.Find(id));
        }

        // POST: Manufactor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Manufactor manufactor = _context.Manufactor.Find(id);
                manufactor.Id = int.Parse(collection["Id"]);
                manufactor.CompanyName = collection["CompanyName"];
                manufactor.Address = collection["Address"];
                manufactor.Province = collection["Province"];
                manufactor.City = collection["City"];
                manufactor.ContactTel = collection["ContactTel"];
                manufactor.RegistDate = DateTime.Parse(collection["RegistDate"]);
                manufactor.Status = collection["Status"];

                //保存到数据库
                _context.SaveChanges();  //自动生成insert 语句
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufactor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Manufactor.Find(id));
        }

        // POST: Manufactor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Manufactor manufactor = _context.Manufactor.Find(id); //先找到原来的值

                if (manufactor != null)
                {
                    _context.Manufactor.Remove(manufactor);  //标识这个数据要被删除 在数据库中还未删除
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