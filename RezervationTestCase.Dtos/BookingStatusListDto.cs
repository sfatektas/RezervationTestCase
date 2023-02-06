using RezervationTestCase.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Dtos
{
    public class BookingStatusListDto : IListDto
    {
        public int Id { get; set; }

        public string  Defination { get; set; }
    }
}
