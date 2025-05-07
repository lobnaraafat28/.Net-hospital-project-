using HospitalManagementSystem.Models.Appointments;
using HospitalManagementSystem.Models.Enums;
using HospitalManagementSystem.Presentation.Areas.Admin.Models;
using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IScheduleService _scheduleService;

        public AppointmentController(IAppointmentService appointmentService,IPatientService patientService,IDoctorService doctorService,IScheduleService scheduleService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> AllAppointments()
        {
            var appointments = await _appointmentService.GetAllAsync();
            var appointmentList = new List<AppointmentVM>();
            foreach (var appointment in appointments)
            {
                var appointmentVM = new AppointmentVM()
                {
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = DateTime.Now.TimeOfDay,
                    DoctorID = appointment.Id,
                    PatientID = appointment.PatientID,
                    ScheduleID = appointment.ScheduleID,

                };
                appointmentList.Add(appointmentVM);
            }
            return View(appointmentList);
        }
        
        public async Task<IActionResult> AddAppointment()
        {
            var appointmentVM = new AppointmentVM()
            {
                Patients = (await _patientService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList(),
                Doctors = (await _doctorService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList(),
                Schedules = (await _scheduleService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.StartTime}-{p.EndTime}"
                }).ToList()
            };


            return View(appointmentVM);


        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment(AppointmentVM appointmentVM)
        {
            if (!ModelState.IsValid)
            {


                appointmentVM.Patients = (await _patientService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                appointmentVM.Doctors = (await _doctorService.GetAllAsync()).Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
                appointmentVM.Schedules = (await _scheduleService.GetAllAsync()).Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.StartTime} - {s.EndTime}"
                }).ToList();

                return View(appointmentVM);
            }

            var appointment = new Appointment()
            {
                AppointmentDateTime = appointmentVM.AppointmentDate,
                Status = Status.Active,
                PatientID = appointmentVM.PatientID,
                DoctorID = appointmentVM.DoctorID,
                ScheduleID = appointmentVM.ScheduleID
            };

            await _appointmentService.AddAsync(appointment);
            return RedirectToAction(nameof(AllAppointments));
        }
        [HttpGet]
             public async Task<IActionResult> EditAppointment(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentVM = new AppointmentVM
            {
                AppointmentID = appointment.Id,
                AppointmentDate = appointment.AppointmentDateTime,
                PatientID = appointment.PatientID,
                DoctorID = appointment.DoctorID,
                ScheduleID = appointment.ScheduleID,
                Patients = (await _patientService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList(),
                Doctors = (await _doctorService.GetAllAsync()).Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList(),
                Schedules = (await _scheduleService.GetAllAsync()).Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.StartTime} - {s.EndTime}"
                }).ToList()
            };

            return View(appointmentVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditAppointment(int id, AppointmentVM appointmentVM)
        {
            if (id != appointmentVM.AppointmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                appointmentVM.Patients = (await _patientService.GetAllAsync()).Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList();
                appointmentVM.Doctors = (await _doctorService.GetAllAsync()).Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList();
                appointmentVM.Schedules = (await _scheduleService.GetAllAsync()).Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.StartTime} - {s.EndTime}"
                }).ToList();

                return View(appointmentVM);
            }
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.AppointmentDateTime = appointmentVM.AppointmentDate;
            appointment.PatientID = appointmentVM.PatientID;
            appointment.DoctorID = appointmentVM.DoctorID;
            appointment.ScheduleID = appointmentVM.ScheduleID;

             _appointmentService.Update(appointment);
            return RedirectToAction(nameof(AllAppointments));


        }
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            appointment.Status = Status.Inactive;

            return RedirectToAction(nameof(AllAppointments));
        }

    }
}
