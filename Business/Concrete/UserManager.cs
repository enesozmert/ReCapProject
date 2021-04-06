using Business.Abstract;
using Business.Constant;
using Business.ValidationRules;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userID)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.ID == userID));
        }

        public IDataResult<List<CustomerDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_userDal.GetCustomerDetails());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

    }
}
