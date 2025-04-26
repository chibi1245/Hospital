namespace Hospital.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number{ get; set; }
        public int Type { get; set; }
        public DateTime CreateTime{ get; set; }
        public string Description  { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }




    }
}