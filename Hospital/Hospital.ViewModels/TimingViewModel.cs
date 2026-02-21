using System;
using System.ComponentModel.DataAnnotations;
using Hospital.Models;

namespace Hospital.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan MorningShiftStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan MorningShiftEndTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan AfternoonShiftStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan AfternoonShiftEndTime { get; set; }

        [Required]
        [Range(1, 1440)]
        public int Duration { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        // Convert ViewModel → Entity
        public Timing ToEntity()
        {
            return new Timing
            {
                Id = this.Id,
                DoctorId = this.DoctorId,
                Date = this.Date,
                MorningShiftStartTime = this.MorningShiftStartTime,
                MorningShiftEndTime = this.MorningShiftEndTime,
                AfternoonShiftStartTime = this.AfternoonShiftStartTime,
                AfternoonShiftEndTime = this.AfternoonShiftEndTime,
                Duration = this.Duration,
                Status = this.Status
            };
        }

        // Populate ViewModel from entity
        public TimingViewModel() { }

        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            Date = model.Date;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            DoctorId = model.DoctorId;
            DoctorName = model.Doctor?.Name ?? model.DoctorId;
        }
    }
}
