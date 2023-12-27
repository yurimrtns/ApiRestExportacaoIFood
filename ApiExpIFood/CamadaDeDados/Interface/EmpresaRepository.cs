using CamadaDeNegócios.Models;
using AutoMapper;

namespace CamadaDeDados.Interface;

public class EmpresaRepository : IEmpresaRepository
{
    private Singleton s;
    private int _id = 1;



    public EmpresaRepository(Singleton s)
    {
        this.s = s;

    }
    
    public List<Empresa> BuscaTodas()
    {
        return s.MostrarEmpresa;
    }

    public List<Empresa> BuscaPorId(int id)
    {
        return s.MostrarEmpresa.Where(e => e.Id == id).ToList();
    }

    public Empresa Inserir(string nome)
    {   
        
        var emp = new Empresa();
        emp.Id = _id++;
        emp.Nome = nome;

        s.MostrarEmpresa.Add(emp);
        return emp;

    }

    public void Atualizar(int id, Empresa empresa)
    {
        var lista = s.MostrarEmpresa.Where(e =>e.Id == id).ToList();

        foreach(var i in lista)
        {
            i.Nome = empresa.Nome;
        }

        
        
    }
}
