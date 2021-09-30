using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vendor.Models;
using System;

namespace Vendor.Tests
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
  }
}