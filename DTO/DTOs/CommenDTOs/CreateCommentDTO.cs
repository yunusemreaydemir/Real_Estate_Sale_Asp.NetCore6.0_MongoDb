using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.CommenDTOs
{
    public class CreateCommentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string UserTitle { get; set; }
    }
}
