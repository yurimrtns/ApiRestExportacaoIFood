using CamadaDeNegócios.Models;

namespace CamadaDeDados.Interface
{
    public interface IEmpresaRepository
    {
        Empresa Inserir(string nome);
        List<Empresa> BuscaTodas();
        List<Empresa> BuscaPorId(int id);

        void Atualizar(int id, Empresa empresa);
     
    }
}
