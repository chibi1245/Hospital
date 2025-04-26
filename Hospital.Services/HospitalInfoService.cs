using Hospital.Model;
using Hospital.Repositories.Interface;
using Hospital.Utilites;
using Hospital.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class HospitalInfoService :IHospitalInfo
    {
        private IUnitOfWork _unitOfWork;

        

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospitalInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(id);
            _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
            _unitOfWork.save();
        }

       

        public PageResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm= new HospitalInfoViewModel();
            int totalCount;
            List<HospitalInfoViewModel> vmlist = new List<HospitalInfoViewModel>();
            try
            {
                int  ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount =_unitOfWork.GenericRepository<HospitalInfo>().GetAll(). ToList().Count;
                vmlist = ConvertModelToViewModelList(modelList);

            }
            catch (Exception )
            {
                throw ;
            }
            var result = new PageResult<HospitalInfoViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                pageSize = pageSize
            };
            return result;
        }

       
        public HospitalInfoViewModel GetHospitalById(int HospitalId)
        {
            var model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(HospitalId);
            var vm = new HospitalInfoViewModel(model);
            return vm;
        }
        public void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model= new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
            _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo)
        {
            var model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfo);
           var ModelById  =  _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);
            ModelById.Name = hospitalInfo.Name;
            ModelById.City = hospitalInfo.City;
            ModelById.PinCode = hospitalInfo.PinCode;
            ModelById.Country = hospitalInfo.Country;
            _unitOfWork.GenericRepository<HospitalInfo>().Update(ModelById);
            _unitOfWork.save();
        }

        private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
        {
            return modelList.Select(x => new HospitalInfoViewModel(x)).ToList();
        }
    }
}