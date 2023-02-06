using RezervationTestCase.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Dtos.CustomerDtos
{
    public class CustomerListDto : IListDto
    {
        public int Id { get; set; }
    }
}
