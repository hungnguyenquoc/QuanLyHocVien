using QuanLyHocVien.Data.Infrastructure;
using QuanLyHocVien.Data.Repositories;
using QuanLyHocVien.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Service
{
    public interface IErrorService
    {
        void Create(Error error);
        //Error Create(Error error);
        void Save();
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
             _errorRepository.Add(error);
        }

        //public IEnumerable<Error> Create(Error error)
        //{
        //    //return _errorRepository.Add(error);
        //}

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
