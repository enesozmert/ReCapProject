using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Brand:IEntity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
