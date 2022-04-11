using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEcartDemo.Models;
using WebAppECartDemo.ViewModel;

namespace WebAppECartDemo.Controllers
{
    public class ItemController : Controller
    {
        private ECartDBEntities1 objECartDbEntities;
        public ItemController()
        {
            objECartDbEntities = new ECartDBEntities1();
        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objECartDbEntities.categories
                select new SelectListItem()
                {
                    Text = objCat.caregoryname,
                    Value = objCat.categoryid.ToString(),
                    Selected = true
                });
            return View(objItemViewModel);
        }

        [HttpPost]
        public JsonResult Index(ItemViewModel objItemViewModel)
        {
            string NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
            objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/"+ NewImage));

            item objItem = new item();
            objItem.imagepath = "~/Images/" + NewImage;
            objItem.categoryid = objItemViewModel.CategoryId;
            objItem.description = objItemViewModel.Description;
            objItem.itemcode = objItemViewModel.ItemCode;
            objItem.itemid = Guid.NewGuid();
            objItem.itemname = objItemViewModel.ItemName;
            objItem.itemprice = objItemViewModel.ItemPrice;
            objECartDbEntities.items.Add(objItem);
            objECartDbEntities.SaveChanges();

            return Json(new {Success = true, Message = "Item is added Successfully."}, JsonRequestBehavior.AllowGet);
        }
    }
}