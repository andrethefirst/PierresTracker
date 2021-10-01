using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Order.Models;
using System;

namespace Order.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderRecieved()
    {
      Order newOrder = new Order("title", "description", "date", "0");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
  }
}