using Azure.Core;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
           _doctorService = doctorService;
        }
     
    }
}
