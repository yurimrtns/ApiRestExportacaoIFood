using CamadaDeNegócios.Models;
using AutoMapper;
using CamadaDeNegócios.Models.Dtos;

namespace CamadaDeNegócios.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<EmpresaDto, Empresa>();
        CreateMap<Empresa, EmpresaDto>();
    }
}
