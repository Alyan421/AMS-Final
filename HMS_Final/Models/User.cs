namespace HMS_Final.Models
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public long OTP { get; set; } // One-Time Password
        public DateTime? OTPExpiry { get; set; } // When the OTP will expire
        public bool IsVerified { get; set; } = false; // Verification status
        public int ResendCount { get; set; } = 0; // Limit resend attempts

        // Many-to-Many relationship with hospitals
        public ICollection<UserHospital> UserHospitals { get; set; }

        // One-to-Many relationship with appointments
        public ICollection<Appointment> Appointments { get; set; }
    }
}
