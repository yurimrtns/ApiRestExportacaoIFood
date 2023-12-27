
using CamadaDeNegócios.Models;
using AutoMapper;
using CamadaDeNegócios.Models.Dtos;

namespace CamadaDeNegócios.Profiles;

public class SegmentoProfile : Profile
{
    public SegmentoProfile()
    {
        CreateMap<SegmentoDto, Segmento>();
        CreateMap<Segmento, SegmentoDto>();
    }
}
