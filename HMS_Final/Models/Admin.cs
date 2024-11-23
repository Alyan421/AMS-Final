namespace HMS_Final.Models
{
    public class Admin : BaseEntity<int>
    { 
        public string UserName {  get; set; }
        public string Password { get; set; }
        //   //foregin key
        //   public int UserId {  get; set; }

        //    //Navigator Property
        //    public User User { get; set; }  

        //one to many
        public ICollection<Hospital> Hospitals { get; set; }
    }
}
