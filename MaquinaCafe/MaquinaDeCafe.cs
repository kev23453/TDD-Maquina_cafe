namespace MaquinaCafe;

public class MaquinaDeCafe
{
    public const string MensajeNoHayVasos = "No hay Vasos";
    public const string MensajeNoHayCafe = "No hay Cafe";
    public const string MensajeNoHayAzucar = "No hay Azucar";
    public const string MensajeExito = "Felicitaciones";

    public const string TipoPequeno = "pequeno";
    public const string TipoMediano = "mediano";
    public const string TipoGrande = "grande";

    public Cafetera Cafetera { get; set; }
    public Vaso VasosPequeno { get; set; }
    public Vaso VasosMediano { get; set; }
    public Vaso VasosGrande { get; set; }
    public Azucarero Azucarero { get; set; }

    /// <summary>
    /// Devuelve el grupo de vasos que corresponde al tamaño pedido
    /// ("pequeno", "mediano" o "grande"), o null si el tamaño no existe.
    /// </summary>
    public Vaso GetTipoDeVaso(string tipoDeVaso)
    {
        switch (tipoDeVaso)
        {
            case TipoPequeno:
                return VasosPequeno;
            case TipoMediano:
                return VasosMediano;
            case TipoGrande:
                return VasosGrande;
            default:
                return null;
        }
    }

    /// <summary>
    /// Intenta servir la cantidad de vasos de café indicada, con las cucharadas
    /// de azúcar pedidas. Primero verifica que haya vasos, café y azúcar (en ese
    /// orden); solo si todo alcanza descuenta los tres. Devuelve el mensaje del
    /// resultado.
    /// </summary>
    public string GetVasoDeCafe(Vaso vaso, int cantidadDeVasos, int cantidadDeAzucar)
    {
        int cafeNecesario = CafeNecesario(vaso, cantidadDeVasos);

        if (!vaso.HasVasos(cantidadDeVasos))
        {
            return MensajeNoHayVasos;
        }
        if (!Cafetera.HasCafe(cafeNecesario))
        {
            return MensajeNoHayCafe;
        }
        if (!Azucarero.HasAzucar(cantidadDeAzucar))
        {
            return MensajeNoHayAzucar;
        }

        vaso.GiveVasos(cantidadDeVasos);
        Cafetera.GiveCafe(cafeNecesario);
        Azucarero.GiveAzucar(cantidadDeAzucar);
        return MensajeExito;
    }

    private static int CafeNecesario(Vaso vaso, int cantidadDeVasos)
    {
        return vaso.Contenido * cantidadDeVasos;
    }
}
