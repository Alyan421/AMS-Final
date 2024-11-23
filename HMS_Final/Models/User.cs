namespace HMS_Final.Models
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Password {  get; set; }
        public long OTP {  get; set; }
        public DateTime? OTPExpiry { get; set; } // When the OTP will expire
        public bool IsVerified { get; set; } = false;
        public int ResendCount { get; set; } = 0; // Limit resend attempts

        //Many-many
        public ICollection<UserHospital> UserHospitals { get; set; }

        ////one to one (Navigator Property)
        //public Admin admin { get; set; }    
    }

}

