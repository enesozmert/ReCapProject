
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Brand:IEntity
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}
