using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public DateTime Date { get; set; }
        public int Cvv { get; set; }
    }
}
