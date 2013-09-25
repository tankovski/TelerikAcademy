using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private IList<Unit> unitList;
        public HomeController()
        {
            this.unitList = new List<Unit>()
            {
                new Unit("bit-b"),
                new Unit("Byte-B"),
                new Unit("Kilobit-Kb"),
                new Unit("Kilobyte-KB"),
                new Unit("Megabit-Mb"),
                new Unit("Megabyte-MB"),
                new Unit("Gigabit-Gb"),
                new Unit("Gygabyte-GB"),
                new Unit("Terabit-Tb"),
                new Unit("Terabyte-TB"),
                new Unit("Petabit-Pb"),
                new Unit("Petabyte-PB"),
                new Unit("Exabit-Eb"),
                new Unit("Exabyte-EB"),
                new Unit("Zetabit-Zb"),
                new Unit("Zetabyte-ZB"),
                new Unit("Yottabit-Yb"),
                new Unit("Yottabyte-YB")
            };
        }

        public ActionResult Index()
        {          
            return View(unitList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TakeValue(string types,int count,int kilo)
        {

            var currentValueIndex = Array.IndexOf(unitList.Select(x=>x.Name).ToArray(),types);

            unitList[currentValueIndex].Value = 1D*count;
            int currentValueLength = unitList[currentValueIndex].Name.Length;

            int biteValue = 0;
            int byteValue = 0;
            if (unitList[currentValueIndex].Name[currentValueLength-1]=='b')
            {
                biteValue =kilo==1000? 125:128;
                byteValue = 8;

                if (currentValueIndex - 1 >= 0)
                {
                    for (int i = currentValueIndex - 1; i >= 0; i--)
                    {
                        if (i + 1 < unitList.Count())
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i + 1].Value * byteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i + 1].Value * biteValue;
                            }

                        }
                    }
                }
                if (currentValueIndex+1<=unitList.Count)
                {
                    for (int i = currentValueIndex+1; i < unitList.Count; i++)
                    {
                        if (i - 1 >= 0)
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i - 1].Value / biteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i - 1].Value / byteValue;
                            }

                        }
                    }
                }
            }
            else
            {
                biteValue = 8;
                byteValue = kilo;

                if (currentValueIndex - 1 >= 0)
                {
                    for (int i = currentValueIndex - 1; i >= 0; i--)
                    {
                        if (currentValueIndex + 1 <= unitList.Count())
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i + 1].Value * biteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i + 2].Value * byteValue;
                            }

                        }
                    }
                }
                if (currentValueIndex + 1 <= unitList.Count)
                {
                    for (int i = currentValueIndex + 1; i < unitList.Count; i++)
                    {
                        if (i - 1 >= 0)
                        {
                            int valueLength = unitList[i].Name.Length;

                            if (unitList[i].Name[valueLength - 1] == 'b')
                            {
                                unitList[i].Value = unitList[i - 2].Value / byteValue;
                            }
                            else
                            {
                                unitList[i].Value = unitList[i - 1].Value / biteValue;
                            }

                        }
                    }
                }
            }

            ViewBag.Message = kilo;
            return View("Index",unitList);
        }
    }
}