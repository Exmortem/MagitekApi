using System;
using System.ComponentModel.DataAnnotations;

namespace MagitekApi.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }       
        public DateTime PostDateTime { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
