using System.ComponentModel.DataAnnotations.Schema;

namespace MagitekApi.Models
{
    [Table("MagitekSettings")]
    public class MagitekSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Job { get; set; }
    }
}
