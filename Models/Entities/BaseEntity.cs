using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKPROFITANDLOSSAPP.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public BaseEntity(int id, DateTime dateCreated)
        {
            Id = id;
            DateCreated = dateCreated;
        }
    }
}
