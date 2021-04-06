using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<CreditCard> GetById(int creditCardID);
        IDataResult<List<CreditCard>> GetByUserId(int userID);
    }
}
