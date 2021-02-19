﻿using Core.Utilities.Results.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color> GetById(int colorID);
    }
}