using CamadaDeNegócios.Models;

namespace CamadaDeDados.Interface;

public class CategoriaRepository : ICategoriaRepository
{
    private Singleton s;
    private int _id = 1;



    public CategoriaRepository(Singleton s)
    {
        this.s = s;

    }

    public List<Categoria> BuscaTodas()
    {
        return s.MostrarCategoria;
    }

    public List<Categoria> BuscaPorId(int id)
    {
        return s.MostrarCategoria.Where(e => e.Id == id).ToList();
    }

    public Categoria Inserir(string nome)
    {

        var cat = new Categoria();
        cat.Id = _id++;
        cat.Nome = nome;

        s.MostrarCategoria.Add(cat);
        return cat;

    }

    public void Atualizar(int id, Categoria categoria)
    {
        var lista = s.MostrarCategoria.Where(e => e.Id == id).ToList();

        foreach (var i in lista)
        {
            i.Nome = categoria.Nome;
        }



    }
}
