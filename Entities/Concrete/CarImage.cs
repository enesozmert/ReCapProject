using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? Date { get; set; }
        public Car CarProp { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public IFormFile[] ImageFiles { get; set; }

    }
}
