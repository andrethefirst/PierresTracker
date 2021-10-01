using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PierresTracker.Models;
using System;

namespace PierresTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorShown()
    {
      Vendor newVendor = new Vendor("name", "description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetAndReturn_NameDescription()
    {
      string name = "Andre";
      string description = "description";
      Vendor newVendor = new Vendor(name, description);
      string recievedName = newVendor.Name;
      string recievedDesc = newVendor.Description;
      Assert.AreEqual(name, recievedName);
      Assert.AreEqual(description, recievedDesc);
    }

    [TestMethod]
    public void GetId_AndReturn()
    {
      string name = "Andre";
      string description = "description";
      Vendor newVendor = new Vendor(name, description);
      int recieved = newVendor.Id;
      Assert.AreEqual(1, recieved);
    }

    [TestMethod]
    public void GetAllItemsReturn()
    {
      string vendor = "Taco Bell";
      string vendordesc = "Fast food for the toilet";
      string secondVendor = "Arby's";
      string secondDesc = "Nobody eats here";
      Vendor newVendor1 = new Vendor(vendor, vendordesc);
      Vendor newVendor2 = new Vendor(secondVendor, secondDesc);
      List<Vendor> newList = new List<Vendor> {newVendor1, newVendor2};
      List<Vendor> result = Vendor.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void FindItems()
    {
      string vendor = "Taco Bell";
      string vendordesc = "Fast food for the toilet";
      string secondVendor = "Arby's";
      string secondDesc = "Nobody eats here";
      Vendor newVendor1 = new Vendor(vendor, vendordesc);
      Vendor newVendor2 = new Vendor(secondVendor, secondDesc);
      Vendor result = Vendor.Find(2);
      Assert.AreEqual(newVendor2, result);
    }
  }
}