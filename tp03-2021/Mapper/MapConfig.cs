using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp03_2021.Entities;
using tp03_2021.ViewModels;

namespace tp03_2021.Mapper
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Cadete, CadeteViewModel>();
            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest=>dest.ClienteId, o => o.MapFrom(s=>s.Cliente.Id))
                .ForMember(dest => dest.CadeteId, o => o.MapFrom(s => s.Cadete.Id));
            CreateMap<Pedido, PedidoGetViewModel>();
            CreateMap<Usuario, RegisterViewModel>().ReverseMap();
        }
    }
}
