using Hospital.Models;
using Hospital.ViewModels;
using Hospital.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Hospital.Repositories;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(ApplicationDbContext context, ILogger<DoctorService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddTiming(TimingViewModel vm)
        {
            _logger.LogInformation("AddTiming called for DoctorId {DoctorId}", vm.DoctorId);
            var entity = vm.ToEntity();
            _context.Timings.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("Timing saved successfully.");
        }

        public void UpdateTiming(TimingViewModel vm)
        {
            var entity = _context.Timings.Find(vm.Id);
            if (entity != null)
            {
                entity.Date = vm.Date;
                entity.MorningShiftStartTime = vm.MorningShiftStartTime;
                entity.MorningShiftEndTime = vm.MorningShiftEndTime;
                entity.AfternoonShiftStartTime = vm.AfternoonShiftStartTime;
                entity.AfternoonShiftEndTime = vm.AfternoonShiftEndTime;
                entity.Duration = vm.Duration;
                entity.Status = vm.Status;
                _context.SaveChanges();
                _logger.LogInformation("Timing updated successfully for Id {Id}", vm.Id);
            }
        }

        public void DeleteTiming(int id)
        {
            var entity = _context.Timings.Find(id);
            if (entity != null)
            {
                _context.Timings.Remove(entity);
                _context.SaveChanges();
                _logger.LogInformation("Timing deleted successfully for Id {Id}", id);
            }
        }

        public TimingViewModel GetTimingById(int id)
        {
            var t = _context.Timings.Include(x => x.Doctor).FirstOrDefault(x => x.Id == id);
            return t != null ? new TimingViewModel(t) : null;
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            return _context.Timings.Include(t => t.Doctor).Select(t => new TimingViewModel(t)).ToList();
        }

        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var query = _context.Timings.Include(t => t.Doctor).OrderByDescending(t => t.Date);
            var total = query.Count();
            var data = query.Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(t => new TimingViewModel(t))
                            .ToList();
            return new PagedResult<TimingViewModel>
            {
                Data = data,
                TotalItems = total,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
