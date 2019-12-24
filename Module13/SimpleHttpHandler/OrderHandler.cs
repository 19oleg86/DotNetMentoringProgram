﻿using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleHttpHandler
{
    class Order
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
    public class OrderHandler : IHttpHandler
    {
        //   https://localhost:port + /handler/?OrderCode=abc&ReturnOrders=3&SkipOrders=1
        List<Order> orders = new List<Order>()
        {
            new Order(){ OrderId = 1, OrderCode = "abc", DateFrom = DateTime.Now, DateTo = DateTime.Now},
            new Order(){ OrderId = 2, OrderCode = "abc", DateFrom = DateTime.Now, DateTo = DateTime.Now},
            new Order(){ OrderId = 3, OrderCode = "abc", DateFrom = DateTime.Now, DateTo = DateTime.Now},
            new Order(){ OrderId = 4, OrderCode = "abc", DateFrom = DateTime.Now, DateTo = DateTime.Now},
            new Order(){ OrderId = 5, OrderCode = "abc", DateFrom = DateTime.Now, DateTo = DateTime.Now},
            new Order(){ OrderId = 6, OrderCode = "xyz", DateFrom = DateTime.Now, DateTo = DateTime.Now}
        };

        List<Order> fileredResultOrders;
        
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;
            if (context.Request.Params["OrderCode"] == "abc" && int.Parse(context.Request.Params["ReturnOrders"]) == 3 && int.Parse(context.Request.Params["SkipOrders"]) == 1)
            {
                var resultOrders = orders.Where(x => x.OrderCode == "abc").ToList();
                fileredResultOrders = resultOrders.GetRange(int.Parse(context.Request.Params["SkipOrders"]), int.Parse(context.Request.Params["ReturnOrders"]));
                foreach (var item in fileredResultOrders)
                {
                    result = result += "<p>OrderId = " + item.OrderId + "</p>";
                }
                
            }
            context.Response.Write(result);

            // Saving report Report.xlsx) in D disk
            if (context.Request.AcceptTypes.Contains("application/xhtml+xml"))
            {
                using (var workbook = new XLWorkbook())
                {
                    int counter = 1;
                    var worksheet = workbook.Worksheets.Add("Sample Sheet");
                    
                    foreach (var item in fileredResultOrders)
                    {
                        worksheet.Cell("A" + counter.ToString()).Value = item.OrderId.ToString();
                        counter++;
                    } 
                    workbook.SaveAs(@"D:\Report.xlsx");
                }
            }
            
        }
    }
}