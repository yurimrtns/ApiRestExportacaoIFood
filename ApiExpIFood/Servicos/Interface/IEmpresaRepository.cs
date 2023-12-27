using ApiExpIFood.Data;
using ApiExpIFood.Models;

namespace ApiExpIFood.Interface
{
    public interface IEmpresaRepository
    {
        Empresa Inserir(string nome);
        List<Empresa> BuscaTodas();
        List<Empresa> BuscaPorId(int id);
     
    }
}
