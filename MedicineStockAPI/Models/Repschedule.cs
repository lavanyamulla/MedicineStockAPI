using System;
using System.Collections.Generic;

namespace MedicineStockAPI.Models
{
    public partial class Repschedule
    {
        public int Id { get; set; }
        public string? RepName { get; set; }
        public string? DoctorName { get; set; }
        public string? TreatingAilment { get; set; }
        public string? Medicine { get; set; }
        public string? MeetingSlot { get; set; }
        public DateTime? DateofMeeting { get; set; }
        public string? DoctorContactNumber { get; set; }
    }
}
