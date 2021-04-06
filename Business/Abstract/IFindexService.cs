using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindexService
    {
        IDataResult<List<Findex>> GetAll();
        IResult Add(Findex findexDto);
        IResult Update(Findex findexDto);
        IResult Delete(Findex findexDto);
        IDataResult<Findex> GetById(int findexDtoID);
        IDataResult<int> GetUserFindex();
        IDataResult<int> GetCarFindex();
    }
}
