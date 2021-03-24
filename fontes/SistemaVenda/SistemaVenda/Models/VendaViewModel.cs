using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }
        
        [DisplayName("Data da venda")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public DateTime? Data { get; set; }
        
        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Informe a {0}!")]
        public int? CodigoCliente { get; set; }
        
        public ClienteViewModel Cliente { get; set; }
        
        public decimal Total { get; set; }

        public string JsonProdutos { get; set; }

        public IEnumerable<SelectListItem> ListaProdutos { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }
    }
}
