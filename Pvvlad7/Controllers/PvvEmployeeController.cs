using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pvvlad7.Models;

namespace Pvvlad7.Controllers
{
    public class PvvEmployeeController : Controller
    {
        // Mock Data:
        private static List<PvvEmployee> pvvlistEmployee = new List<PvvEmployee>()
        {
            new PvvEmployee
    {
        PvvId = 310900120,
        PvvName = "Phạm Văn Vũ",
        PvvBirthDay = new DateTime(2005, 3, 1),
        PvvEmail = "phamvanvu010305@gmail.com",
        PvvPhone = "0347533802",
        PvvSalary = 15000000m,
        PvvStatus = true
    },
    new PvvEmployee
    {
        PvvId = 2,
        PvvName = "Trần Thị B",
        PvvBirthDay = new DateTime(1985, 8, 23),
        PvvEmail = "tranthib@example.com",
        PvvPhone = "0912345678",
        PvvSalary = 18000000m,
        PvvStatus = true
    },
    new PvvEmployee
    {
        PvvId = 3,
        PvvName = "Lê Văn C",
        PvvBirthDay = new DateTime(1992, 3, 15),
        PvvEmail = "levanc@example.com",
        PvvPhone = "0923456789",
        PvvSalary = 12000000m,
        PvvStatus = false
    },
    new PvvEmployee
    {
        PvvId = 4,
        PvvName = "Phạm Thị D",
        PvvBirthDay = new DateTime(1995, 12, 5),
        PvvEmail = "phamthid@example.com",
        PvvPhone = "0934567890",
        PvvSalary = 17000000m,
        PvvStatus = true
    },
    new PvvEmployee
    {
        PvvId = 5,
        PvvName = "Hoàng Văn E",
        PvvBirthDay = new DateTime(1988, 7, 30),
        PvvEmail = "hoangvane@example.com",
        PvvPhone = "0945678901",
        PvvSalary = 16000000m,
        PvvStatus = false
    }
        };
        // GET: PvvEmployeeController
        public ActionResult PvvIndex()
        {
            return View(pvvlistEmployee);
        }

        // GET: PvvEmployeeController/PvvDetails/5
        public ActionResult PvvDetails(int id)
        {
            var pvvEmployee = pvvlistEmployee.FirstOrDefault(x => x.PvvId == id); 
            return View(pvvEmployee);
        }

        // GET: PvvEmployeeController/PvvCreate
        public ActionResult PvvCreate()
        {
            var pvvEmployee = new PvvEmployee();
            return View(pvvEmployee);
        }

        // POST: PvvEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PvvCreate(PvvEmployee pvvModel)
        {
            try
            {
                //Thêm mới nhân viên vào list
                pvvModel.PvvId = pvvlistEmployee.Max(x => x.PvvId) + 1;
                pvvlistEmployee.Add(pvvModel);
                return RedirectToAction(nameof(PvvIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: PvvEmployeeController/PvvEdit/5
        public ActionResult PvvEdit(int id)
        {
            var pvvEmployee = pvvlistEmployee.FirstOrDefault(x => x.PvvId == id);
            return View(pvvEmployee);
        }

        // POST: PvvEmployeeController/PvvEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PvvEdit(int id, PvvEmployee pvvModel)
        {
            try
            {
                for (int i = 0; i < pvvlistEmployee.Count; i++)
                {
                    if (pvvlistEmployee[i].PvvId == id)
                    {
                        pvvlistEmployee[i] = pvvModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(PvvIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: PvvEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PvvEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
