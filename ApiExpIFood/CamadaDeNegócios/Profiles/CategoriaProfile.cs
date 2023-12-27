namespace CamadaDeNegócios.Profiles;

using CamadaDeNegócios.Models.Dtos;
using CamadaDeNegócios.Models;
using AutoMapper;
public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaDto, Categoria>();
        CreateMap<Categoria, CategoriaDto>();
    }
}
