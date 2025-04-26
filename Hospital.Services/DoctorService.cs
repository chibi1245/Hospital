using Hospital.Model;
using Hospital.Repositories.Interface;
using Hospital.Utilites;
using Hospital.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model = timing.ConvertViewModelToModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.save();
        }

        public void DeleteTiming(int id)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(id);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmlist = new List<TimingViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Timing>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;
                vmlist = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<TimingViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                pageSize = pageSize
            };
            return result;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }
        
        
        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmlist = ConvertModelToViewModelList(TimingList);
            return vmlist;
        }

        public TimingViewModel GetTimingById(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            var vm = new TimingViewModel();
          
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
           var model=new TimingViewModel();
            var ModelById= _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            ModelById.Id = timing.Id;
            ModelById.Daytime = timing.Daytime;
            ModelById.morningshiftstart = timing.morningshiftstart;
            ModelById.morningshiftend = timing.morningshiftend;
            ModelById.Afternoonshiftstart = timing.Afternoonshiftstart;
            ModelById.Afternoonshiftend = timing.Afternoonshiftend;
            ModelById.duration = timing.duration;
            ModelById.Status = timing.Status;
            ModelById.DoctorId= timing.DoctorId;
            _unitOfWork.GenericRepository<Timing>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
