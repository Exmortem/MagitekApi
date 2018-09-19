using System.ComponentModel.DataAnnotations;

namespace MagitekApi.Models
{
    public class SharedOpener
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Job { get; set; }
        public string File { get; set; }
        public string Created { get; set; }
        public string PosterId { get; set; }
        public int NumberOfActions { get; set; }
        public string Zone { get; set; }
    }
}
