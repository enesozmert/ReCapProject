using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalDetailDto : IDto
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string BrandName { get; set; }
        public string FullName { get; set; }
        public bool isEnabled { get; set; }

    }
}
