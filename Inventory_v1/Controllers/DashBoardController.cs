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






        [HttpPost]
        public ActionResult Index(string btnSubmit, FormCollection formCollection)     // eikhaner inpt gulo constant na variable hoye geche, FormCollection er maddhome data form theke back e carry korbo 
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            int ReturnStatus = 0;

            if (btnSubmit == "Update")
            {
                baseEquipment.EquipmentID = Convert.ToInt32(formCollection["EquipmentID"].ToString());
                baseEquipment.EquipmentName = formCollection["txtEquipmentName"].ToString();
                baseEquipment.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                baseEquipment.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                baseEquipment.ReceiveDate = Convert.ToDateTime(formCollection["txtReceiveDate"].ToString());
                ReturnStatus = baseEquipment.SaveEquipment();  // Update function call kora hoise
            }

            if (btnSubmit == "Delete")
            {
                //  
                
            }

            if (btnSubmit == "Save")
            {
                baseEquipment.EquipmentName = formCollection["txtEquipmentName"].ToString();
                baseEquipment.Quantity = Convert.ToInt32(formCollection["txtQuantity"].ToString());
                baseEquipment.EntryDate = Convert.ToDateTime(formCollection["txtEntryDate"].ToString());
                baseEquipment.ReceiveDate = Convert.ToDateTime(formCollection["txtReceiveDate"].ToString());
                ReturnStatus = baseEquipment.SaveEquipment();  // save function call kora hoise
            }

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
            if (ReturnStatus > 0)
                ViewBag.OutMessage = "Operation Successfully";  // data save hoye gele message ta dekhabe

            return View();
        }



        //public ActionResult Save()        // Alada vabe amra save korte caile ei method ta use korte pari, means Insert Update Delete amra caile alada function use kore o korte pari and caile amra sob kisu 1ta function er majheo likhte pari

        //{
        //    return View();
        //}


    }
}