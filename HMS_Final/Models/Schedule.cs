namespace HMS_Final.Models
{
    public class Schedule : BaseEntity<int>
    {
        public int Id { get; set; }
        public string ConsultationDay { get; set; } // e.g., Monday
        public string ConsultationTime { get; set; } // e.g., 3:30 PM
        public DateTime ConsultationDate { get; set; } // To handle bookings for specific dates

        // Foreign Key
        public int DoctorId { get; set; }

        // Navigation Properties
        public Doctor Doctor { get; set; }

        //many-many
        public ICollection<Appointment> Appointments { get; set; } // One-to-Many with Appointment

    }
}
