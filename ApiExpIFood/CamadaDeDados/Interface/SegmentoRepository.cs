using CamadaDeNegócios.Models;
using AutoMapper;
using CamadaDeNegócios.Models.Dtos;

namespace CamadaDeDados.Interface;

public class SegmentoRepository : ISegmentoRepository
{
    private Singleton s;
    private int _id = 1;



    public SegmentoRepository(Singleton s)
    {
        this.s = s;

    }

    public List<Segmento> BuscaTodos()
    {
        return s.MostrarSegmento;
    }

    public List<Segmento> BuscaPorId(int id)
    {
        return s.MostrarSegmento.Where(e => e.Id == id).ToList();
    }

    public Segmento Inserir(string nome)
    {

        var seg = new Segmento();
        seg.Id = _id++;
        seg.Nome = nome;

        s.MostrarSegmento.Add(seg);
        return seg;

    }

    public void Atualizar(int id, Segmento segmento)
    {
        var lista = s.MostrarSegmento.Where(e => e.Id == id).ToList();

        foreach (var i in lista)
        {
            i.Nome = segmento.Nome;
        }



    }
}
