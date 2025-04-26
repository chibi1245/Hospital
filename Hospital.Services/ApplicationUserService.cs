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
    public class ApplicationUserService : IApplicationUserSerivce
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmlist = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;
                vmlist = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<ApplicationUserViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                pageSize = pageSize
            };
            return result;

        }

        

        public PageResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmlist = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsDoctor==true).Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count;
                vmlist = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PageResult<ApplicationUserViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                pageSize = pageSize
            };
            return result;
        }

        public PageResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PageResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string spicility = null)
        {
            throw new NotImplementedException();
        }
        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}
