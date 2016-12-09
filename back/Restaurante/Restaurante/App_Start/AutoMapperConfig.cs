using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Services.DTOs;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Produto, ProdutoDto>().ReverseMap();
            Mapper.CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Produtos, opts => opts.MapFrom(src => src.PedidosDoProduto));
            Mapper.CreateMap<PedidoDto, Pedido>()
                .ForMember(dest => dest.PedidosDoProduto, opts => opts.MapFrom(src => src.Produtos));
            Mapper.CreateMap<PedidosDoProduto, PedidosDoProdutoDto>().ReverseMap();
            Mapper.CreateMap<Conta, ContaDto>().ReverseMap();
            Mapper.CreateMap<PedidoViewModel, Pedido>().ReverseMap();
            Mapper.CreateMap<Mesa, MesaViewModel>().ReverseMap();
            Mapper.CreateMap<Conta, ContaViewModel>().ReverseMap();
        }
    }
}