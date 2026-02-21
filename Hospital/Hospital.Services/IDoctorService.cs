using System.Collections.Generic;
using Hospital.ViewModels;
using Hospital.Utilities;

namespace Hospital.Services
{
    public interface IDoctorService
    {
        void AddTiming(TimingViewModel vm);
        void UpdateTiming(TimingViewModel vm);
        void DeleteTiming(int id);
        TimingViewModel GetTimingById(int id);
        IEnumerable<TimingViewModel> GetAll();
        PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);
    }
}
