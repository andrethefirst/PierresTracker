using Microsoft.AspNetCore.Mvc;
using PierresTracker.Models;
using System.Collections.Generic;
using System;

namespace PierresTracker.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> allCat = Vendor.GetAll();
      return View(allCat);
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendor")]
    public ActionResult Create(string vendorName, string description)
    {
      Vendor newVendor = new Vendor(vendorName, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor arbyVendor = Vendor.Find(id);
      List<Order> vendorOrders = arbyVendor.Orders;
      model.Add("vendor", arbyVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendor/{vendorId}/orders")]
    public ActionResult New(int vendorId, string title, string description, string date, string price)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor arbyVendor = Vendor.Find(vendorId);
      Order newOrder =new Order(title, description, date, price);
      arbyVendor.AddOrder(newOrder);
      List<Order> vendorOrders = arbyVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", arbyVendor);
      return View("Show", model);
    }
  }
}