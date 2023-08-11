using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.AdvertDTOs
{
    public class ResultAdvertDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
    }
}
