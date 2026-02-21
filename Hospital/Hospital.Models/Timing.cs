using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Timing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public ApplicationUser Doctor { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan MorningShiftStartTime { get; set; }

        [Required]
        public TimeSpan MorningShiftEndTime { get; set; }

        [Required]
        public TimeSpan AfternoonShiftStartTime { get; set; }

        [Required]
        public TimeSpan AfternoonShiftEndTime { get; set; }

        [Required]
        [Range(1, 1440)]
        public int Duration { get; set; }

        [Required]
        public Status Status { get; set; }
    }

    public enum Status
    {
        Pending,
        Approved,
        Rejected
    }
}
