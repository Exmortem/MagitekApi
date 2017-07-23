using System.ComponentModel.DataAnnotations;

namespace MagitekApi.Models
{
    public class Contributor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretKey { get; set; }
    }
}
