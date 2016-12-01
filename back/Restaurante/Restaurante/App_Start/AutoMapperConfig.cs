using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Potatotech.GestaoRestaurante.Dominio.Models;
using Potatotech.GestaoRestaurante.Web.ViewModels;

namespace Potatotech.GestaoRestaurante.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Pedido, PedidoViewModel>());
        }
    }
}