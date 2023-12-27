using CamadaDeNegócios.Models;

namespace CamadaDeDados.Interface;

public class Singleton
{
    private static Singleton _instance;

    public Singleton()
    {
        MostrarEmpresa = new List<Empresa>();
        MostrarSegmento = new List<Segmento>();
        MostrarCategoria = new List<Categoria>();
    }

    public static Singleton GetSingleton()
    {
        if (_instance == null)
            _instance = new Singleton();

        return _instance;
    }

    public List<Empresa> MostrarEmpresa { get; set; }
    public List<Segmento> MostrarSegmento { get; set; }
    public List<Categoria> MostrarCategoria { get; set; }
}
