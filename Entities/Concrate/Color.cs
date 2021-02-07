using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Color:IEntity
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }
    }
}
