using System.ComponentModel.DataAnnotations;

namespace MagitekApi.Models
{
    public class MagitekSettings
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; } = 0;
        public string File { get; set; }
        public string Created { get; set; }
    }
}
