using Microsoft.AspNetCore.Mvc;
using Pvvlab6.Models;

namespace Pvvlab6.Controllers
{
    public class PvvEmployeeController : Controller
    {
        private static List<PvvEmployee> htvListEmployee = new List<PvvEmployee>() 
        {new PvvEmployee
            {
                PvvId = 1,
                PvvName = "Phạm Văn Vũ",
                PvvBirthDay = new DateTime(2005, 3, 1),
                PvvEmail = "phamvanvu010305@gmail.com",
                PvvPhone = "0347522802",
                PvvSalary = 15000000m,
                PvvStatus = true
            },
            new PvvEmployee
            {
                PvvId = 2,
                PvvName = "Tran Thi B",
                PvvBirthDay = new DateTime(1985, 7, 22),
                PvvEmail = "thib.tran@example.com",
                PvvPhone = "0987654321",
                PvvSalary = 18000000m,
                PvvStatus = true
            },
            new PvvEmployee
            {
                PvvId = 3,
                PvvName = "Le Van C",
                PvvBirthDay = new DateTime(1992, 12, 5),
                PvvEmail = "vanc.le@example.com",
                PvvPhone = "0909123456",
                PvvSalary = 13000000m,
                PvvStatus = false
            }
        };

        public IActionResult PvvIndex()
        {
            return View(htvListEmployee);
        }
        // Action GET:/PvvEmployee/HvtCreate
        public IActionResult PvvCreate()
        {
            return View();
        }
    }
}
