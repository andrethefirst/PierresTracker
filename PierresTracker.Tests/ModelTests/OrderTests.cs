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

    [TestMethod]
    public void CheckProperties()
    {
      string title = "Arby's roast beef";
      string description = "Deliver 2 Arby's roast beef sandwiches";
      string date = "April 28th, 2000";
      string price  = "12";
      Order newOrder = new Order(title, description, date, price);
      string recievedTitle = newOrder.Title;
      string receivedDesc = newOrder.Description;
      string receivedDate = newOrder.Date;
      string recievedPrice = newOrder.Price;
      Assert.AreEqual(title, recievedTitle);
      Assert.AreEqual(description, recievedDesc);
      Assert.AreEqual(date, receivedDate);
      Assert.AreEqual(price, recievedPrice);
    }

    [TestMethod]
    public void GetAllItemsReturn()
    {
      List<Order> newList = new List<Order> { };
      List<Order> recieved = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAllReturnOrders()
    {
      string title = "Arby's roast beef";
      string description = "Deliver 2 Arby's roast beef sandwiches";
      string date = "April 28th, 2000";
      string price = "12";
      string title2 = "Taco bell Taco";
      string description2 = "Deliver Taco's to the hospital";
      string date2 = "April 27th, 2000";
      string price2 = "11";
      Order newOrder = new Order(title, description, date, price);
      Order newOrder1 = new Order(title2, description2, date2, price2);
      List<Order> newList = new List<Order> { newOrder, newOrder1 };
      List<Order> recieved = Order.GetAll();
      CollectionAssert.AreEqual(newList, recieved);
    }

    [TestMethod]
    public void FindCorrectOrder()
    {
      string title = "Arby's roast beef";
      string description = "Deliver 2 Arby's roast beef sandwiches";
      string date = "April 28th, 2000";
      string price = "12";
      string title2 = "Taco bell Taco";
      string description2 = "Deliver Taco's to the hospital";
      string date2 = "April 27th, 2000";
      string price2 = "11";
      Order newOrder = new Order(title, description, date, price);
      Order newOrder1 = new Order(title2, description2, date2, price2);
      Order result = Order.Find(2);
      Assert.AreEqual(newOrder1, result);
    }
  }
}