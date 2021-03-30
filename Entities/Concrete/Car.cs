
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{

    public class Car : IEntity
    {
        public int ID { get; set; }
        public int? BrandID { get; set; }
        public int? ColorID { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public Brand BrandProp { get; set; }
        public Color ColorProp { get; set; }
        public Rental RentalProp { get; set; }
        public CarImage CarImageProp { get; set; }
    }
}
