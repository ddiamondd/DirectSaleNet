using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectSaleNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectSaleNet.Controllers
{
    public class ProductController : Controller
    {
        private readonly Models.DirectSaleContext _context;
        public ProductController(Models.DirectSaleContext context)
        {
            _context = context;
        }
        // GET: Product
        public ActionResult Index() //获取所有商品
        {
            return View(_context.Product.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)  //根据主键 获取明细信息
        {
            return View(_context.Product.Find(id));
        }

        // GET: Product/Create    
        //默认是 GET
        public ActionResult Create() //添加一个商品  insert
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)//根据 表单信息保存
        {
            //Product product = new Product();
            //PRopertyInfo[] propertyInfo = typeof(Product).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags)
            //foreach(PropertyInfo p in propertyInfo)
            //{

            //}
            try
            {
                Product product = new Product();
                product.ProductName = collection["ProductName"];
                product.Brand = collection["Brand"];
                product.StockQuantity = int.Parse(collection["StockQuantity"]);
                product.Price = decimal.Parse(collection["Price"]);
                product.Spec = collection["Spec"];
                product.Description = collection["Description"];
                product.ManufactorId = int.Parse(collection["ManufactorId"]);

                //然后把商品添加到商品集合中去
                _context.Product.Add(product);

                //保存到数据库
                _context.SaveChanges();  //自动生成insert 语句


                return RedirectToAction(nameof(Index));  //如果保存成功的话 跳转到商品列表
            }
            catch
            {
                return View(); //不成功的话 返回列表页面
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)  //编辑的时候  首先要把商品原来的信息返回去  在此基础上做修改  
        {
            return View(_context.Product.Find(id)); //根据id查找商品
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)  //这是保存的时候
        {
            try
            {
                // TODO: Add update logic here
                Product product = _context.Product.Find(id); //修改原来的值
                product.ProductName = collection["ProductName"];
                product.Brand = collection["Brand"];
                product.StockQuantity = int.Parse(collection["StockQuantity"]);
                product.Price = decimal.Parse(collection["Price"]);
                product.Spec = collection["Spec"];
                product.Description = collection["Description"];
                product.ManufactorId = int.Parse(collection["ManufactorId"]);

                //保存到数据库
                _context.SaveChanges();  //自动生成insert 语句
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Product.Find(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Product product = _context.Product.Find(id); //先找到原来的值
                
                if(product != null)
                {
                    _context.Product.Remove(product);  //标识这个数据要被删除 在数据库中还未删除
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}