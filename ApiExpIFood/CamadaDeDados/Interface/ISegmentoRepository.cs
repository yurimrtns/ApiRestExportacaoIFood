using CamadaDeNegócios.Models;

namespace CamadaDeDados.Interface
{
    public interface ISegmentoRepository
    {
        Segmento Inserir(string nome);
        List<Segmento> BuscaTodos();
        List<Segmento> BuscaPorId(int id);

        void Atualizar(int id, Segmento segmento);

    }
}
