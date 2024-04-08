using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class ProductosModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "El campo categoría es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo categoría es requerido")]
        public string categoria { get; set; }
        [Required(ErrorMessage = "El campo categoría es requerido")]
        public float precio { get; set; }
        [Required(ErrorMessage = "El campo categoría es requerido")]
        public DateTime fecha { get; set; }

      
        

    
    }
}
