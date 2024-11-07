using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitorapp.Models
{
 
    public class RiskAssessment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public int HeartRate { get; set; }

        [Required]
        public int OxygenLevel { get; set; }

        [Required]
        public string RiskStatus { get; set; } // "Normal" or "High Risk"

        public static string AssessRisk(int heartRate, int oxygenLevel)
        {
            // Define thresholds for risk
            int highRiskHeartRate = 100; // Example: heart rate above 100 is risky
            int lowOxygenLevel = 90;     // Example: oxygen level below 90 is risky

            // Assess risk based on thresholds
            if (heartRate > highRiskHeartRate || oxygenLevel < lowOxygenLevel)
            {
                return "High Risk";
            }
            return "Normal";
        }
    }
}
