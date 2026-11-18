namespace MaquinaCafe;

public class Azucarero
{
    public int CantidadAzucar { get; private set; }

    public Azucarero(int cantidadDeAzucar)
    {
        CantidadAzucar = cantidadDeAzucar;
    }

    public bool HasAzucar(int cantidadDeAzucar)
    {
        return CantidadAzucar >= cantidadDeAzucar;
    }

    public void GiveAzucar(int cantidadDeAzucar)
    {
        CantidadAzucar -= cantidadDeAzucar;
    }
}
