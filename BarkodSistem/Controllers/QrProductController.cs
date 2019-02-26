using BarkodSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BarkodSistem.Controllers
{
    public class QrProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: QrProduct
        public ActionResult Index()
        {
            //QrProductViewModels vm = new QrProductViewModels()
            //{
            //    CategoryID=db.Products.FirstOrDefault().CategoryID,
            //    ProductID=db.Products.FirstOrDefault().ProductID,
            //    ProductionDate= db.Products.FirstOrDefault().QrCodeInfo.ProductionDate,
            //    ProductName =db.Products.FirstOrDefault().ProductName,
            //    Size=db.Products.FirstOrDefault().Size,
            //    SKT=db.Products.FirstOrDefault().QrCodeInfo.SKT,
            //    TETT= db.Products.FirstOrDefault().QrCodeInfo.TETT,
            //    UnitsInStock =db.Products.FirstOrDefault().UnitsInStock,

            //};

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.ProductID = new SelectList(db.QrCodeInfos, "QrcodeInfoID", "QrcodeInfoID");

            return View();
        }

        [HttpPost]
        public ActionResult Create(QrProductViewModels vm)
        {

            QrCodeInfo qr = new QrCodeInfo();
            qr.ProductionDate = vm.ProductionDate;
            qr.SKT = vm.SKT;
            qr.TETT = vm.TETT;

            db.QrCodeInfos.Add(qr);
            db.SaveChanges();

            int sonqr = db.QrCodeInfos.OrderByDescending(x => x.QrCodeInfoID).FirstOrDefault().QrCodeInfoID;
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName",vm.CategoryID);
            Product p = new Product();
            p.ProductName = vm.ProductName;
            //p.QrCodeInfoID = vm.QrCodeInfoID;
            p.Size = vm.Size;
            p.UnitsInStock = vm.UnitsInStock;
            p.CategoryID = vm.CategoryID;
            p.ProductID = sonqr;

            db.Products.Add(p);
            db.SaveChanges();

            return View(vm);
        }

        [HttpGet]
        public JsonResult Listele()
        {

            var result = (from p in db.Products
                          join a in db.QrCodeInfos on p.ProductID equals a.QrCodeInfoID
                          select new QrProductViewModels
                          {
                              ProductID = p.ProductID,
                              QrCodeInfoID = a.QrCodeInfoID,
                              ProductName = p.ProductName,
                              ProductionDate = a.ProductionDate,
                              Size = p.Size,
                              SKT = a.SKT,
                              TETT = a.TETT,
                              CategoryID = p.CategoryID,
                              UnitsInStock = p.UnitsInStock
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}