using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Color:IEntity
    {
        public int ID { get; set; }
        public string ColorName { get; set; }
        public Car CarProp { get; set; }
    }
}
