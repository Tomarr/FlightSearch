using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using FlightSearch.Models;

namespace FlightSearch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var csvAirports =System.IO.File.ReadAllText(Server.MapPath(@"~/CSVFiles/airports.csv"));
          TextReader txtReader= new StringReader(csvAirports);
            var csv = new CsvReader(txtReader); 
            var records = csv.GetRecords<AirPort>().ToList();
            ViewBag.AirportsFrom = records; 
            ViewBag.AirportsTo = records;
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult SearchFlights(string from, string to,string sort="")
        { 
            
            //loading the Flights csv file 
            var csvFlights = System.IO.File.ReadAllText(Server.MapPath(@"~/CSVFiles/flights.csv"));
            TextReader txtReader = new StringReader(csvFlights);
            var csv = new CsvReader(txtReader);
            // apply search parameter to the list 
            var records = csv.GetRecords<Flight>().Where(m=> m.From== from && m.To==to);
            
            
            if (sort == "departs")
                records = records.OrderBy(m => m.Departs);
            else if (sort == "arrives")
                records = records.OrderBy(m => m.Arrives);
            else if (sort == "FirstClassPrice")
                records = records.OrderBy(m => m.FirstClassPrice);
            else if (sort == "MainCabinPrice")
                records = records.OrderBy(m => m.MainCabinPrice);
 
            return Json(records);
        }
    }
}