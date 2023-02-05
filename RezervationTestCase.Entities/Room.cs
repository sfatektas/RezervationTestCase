using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Entities
{
    public class Room : BaseEntity
    {
        public int Capacity { get; set; }

        public decimal DailyPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
