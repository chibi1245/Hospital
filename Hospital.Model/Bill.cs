namespace Hospital.Model
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public  Insurance Insurance { get; set; }
        public int DoctorCharges{ get; set; }
        public decimal RoomCharges{ get; set; }
        public decimal OperationCharges { get; set; }
        public int NoOfDays { get; set; }
        public int  NursingCharge{ get; set; }
        public int  LabCharges{ get; set; }
        public decimal Advanced { get; set; }
        public decimal TotalBill { get; set; }
    }
}