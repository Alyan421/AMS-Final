namespace HMS_Final.Models
{
    public class Hospital : BaseEntity<int>
    {
        public string Name {  get; set; }
        public int ContactInfo {  get; set; }

        //Foreign Key
        public int CityId {  get; set; }
        public int AdminId {  get; set; }

        //Naviagation Propery
        public Admin Admin { get; set; }
        public City City { get; set; }

        //many-many
        public ICollection<HospitalDepartment> HospitalDepartments { get; set; }
        public ICollection<UserHospital> UserHospitals { get; set; }


    }
}
