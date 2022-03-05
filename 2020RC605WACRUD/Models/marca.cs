using System.ComponentModel.DataAnnotations;
namespace _2020RC605WACRUD.Models
{
    public class marca
    {
        [Key]
        public int id_marcas { get; set; }
        public string nombre_marca { get; set; }
        public char estados { get; set; }
    }
}
