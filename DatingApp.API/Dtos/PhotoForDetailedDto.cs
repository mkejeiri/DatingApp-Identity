using System;
using System.Collections.Generic;
//Data transfer object (DTO)
namespace DatingApp.API.Dtos
{
    public class PhotoForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}