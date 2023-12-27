using CamadaDeNegócios.Models;

namespace CamadaDeDados.Interface
{
    public interface ICategoriaRepository
    {
        Categoria Inserir(string nome);
        List<Categoria> BuscaTodas();
        List<Categoria> BuscaPorId(int id);

        void Atualizar(int id, Categoria categoria);

    }
}
