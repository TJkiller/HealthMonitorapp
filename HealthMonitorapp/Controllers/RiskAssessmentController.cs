using HealthMonitorapp.Data;
using HealthMonitorapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HealthMonitorapp.Controllers
{
    public class RiskAssessmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiskAssessmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var assessments = _context.RiskAssessments.ToList();
            return View(assessments);
        }

        [HttpPost]
        public IActionResult Create(int patientId, int heartRate, int oxygenLevel)
        {
            var riskStatus = RiskAssessment.AssessRisk(heartRate, oxygenLevel);

            var newAssessment = new RiskAssessment
            {
                PatientId = patientId,
                Timestamp = DateTime.Now,
                HeartRate = heartRate,
                OxygenLevel = oxygenLevel,
                RiskStatus = riskStatus
            };

            _context.RiskAssessments.Add(newAssessment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
