using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;

        public DepartmentController(IDepartmentService departmentService, IDoctorService doctorService)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
        }

      
    }
}