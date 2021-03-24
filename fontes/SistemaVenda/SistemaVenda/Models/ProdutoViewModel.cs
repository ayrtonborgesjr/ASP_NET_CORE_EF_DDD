using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }
        
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public string Descricao { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public double Quantidade { get; set; }

        [DisplayName("Valor Unitário")]
        [Required(ErrorMessage = "Informe a {0}!")]
        [Range(0.1, double.PositiveInfinity)]
        public decimal? Valor { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public int? CodigoCategoria { get; set; }

        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

        public string DescricaoCategoria { get; set; }
    }
}
