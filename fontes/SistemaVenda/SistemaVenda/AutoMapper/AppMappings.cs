using AutoMapper;
using Dominio.DTO;
using Dominio.Entidades;
using SistemaVenda.Models;

namespace Aplicacao.AutoMapper
{
    public class AppMappings : Profile
    {
        public AppMappings()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(prod => prod.DescricaoCategoria,
                           map => map.MapFrom(src => src.Categoria.Descricao));
            CreateMap<GraficoDTO, GraficoViewModel>().ReverseMap();
        }
    }
}
