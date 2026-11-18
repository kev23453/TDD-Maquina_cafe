namespace MaquinaCafe;

/// <summary>
/// Depósito de café de la máquina.
/// </summary>
public class Cafetera
{
    public int CantidadCafe { get; private set; }

    public Cafetera(int cantidadCafe)
    {
        CantidadCafe = cantidadCafe;
    }

    public bool HasCafe(int cantidadCafe)
    {
        return CantidadCafe >= cantidadCafe;
    }

    public void GiveCafe(int cantidadCafe)
    {
        CantidadCafe -= cantidadCafe;
    }
}
