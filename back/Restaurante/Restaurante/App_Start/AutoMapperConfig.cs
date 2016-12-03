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
            Mapper.CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            Mapper.CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}