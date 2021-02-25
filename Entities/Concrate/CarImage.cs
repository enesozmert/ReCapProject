using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class CarImage:IEntity
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Date { get; set; }
        public Car CarProp { get; set; }
    }
}
