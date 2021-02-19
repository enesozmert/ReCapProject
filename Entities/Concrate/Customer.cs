using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    public class Customer:IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public Rental RentalProp { get; set; }
    }
}
