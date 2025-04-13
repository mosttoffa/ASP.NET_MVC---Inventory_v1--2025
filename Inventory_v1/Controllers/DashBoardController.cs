using Inventory_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_v1.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            List<BaseEquipment> lstEquipment = baseEquipment.ListEquipment();


            //// Only Laptop product ta dekhaite cai so tr jonno ei condition/code
            //List<BaseEquipment> lstEquipment_laptop = new List<BaseEquipment>();
            //foreach (BaseEquipment obj in lstEquipment)
            //{
            //    if (obj.EquipmentName.Contains("Laptop"))
            //    {
            //        lstEquipment_laptop.Add(obj);
            //    }
            //}
            //ViewBag.lstEquipment = lstEquipment_laptop;



            ViewBag.lstEquipment = lstEquipment;

            return View();
        }
    }
}