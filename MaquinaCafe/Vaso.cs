namespace MaquinaCafe;

public class Vaso
{
    public int CantidadVasos { get; private set; }
    public int Contenido { get; private set; }

    public Vaso(int cantidadVasos, int contenido)
    {
        CantidadVasos = cantidadVasos;
        Contenido = contenido;
    }

    public bool HasVasos(int cantidadVasos)
    {
        return CantidadVasos >= cantidadVasos;
    }

    public void GiveVasos(int cantidadVasos)
    {
        CantidadVasos -= cantidadVasos;
    }
}
