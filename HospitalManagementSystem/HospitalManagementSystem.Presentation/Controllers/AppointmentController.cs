using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Presentation.ViewModels;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Presentation.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

       
    }
}
