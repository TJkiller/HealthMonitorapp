namespace HealthMonitorapp.Models
{
    
        public class PatientData
        {
            public int Id { get; set; }
            public string PatientId { get; set; }
            public DateTime Timestamp { get; set; }
            public int HeartRate { get; set; }
            public float OxygenLevel { get; set; }
            public bool Alert { get; set; }
        }
    }


