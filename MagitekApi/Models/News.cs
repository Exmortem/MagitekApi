using System.ComponentModel.DataAnnotations;

namespace MagitekApi.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }       
        public string Created { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
