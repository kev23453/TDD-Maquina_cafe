using Xunit;

namespace MaquinaCafe.Tests;

public class MaquinaDeCafeTests
{
    private Cafetera cafetera;
    private Vaso vasosPequeno;
    private Vaso vasosMediano;
    private Vaso vasosGrande;
    private Azucarero azucarero;
    private MaquinaDeCafe maquinaDeCafe;

    public MaquinaDeCafeTests()
    {
        cafetera = new Cafetera(50);
        vasosPequeno = new Vaso(5, 10);
        vasosMediano = new Vaso(5, 20);
        vasosGrande = new Vaso(5, 30);
        azucarero = new Azucarero(20);

        maquinaDeCafe = new MaquinaDeCafe();
        maquinaDeCafe.Cafetera = cafetera;
        maquinaDeCafe.VasosPequeno = vasosPequeno;
        maquinaDeCafe.VasosMediano = vasosMediano;
        maquinaDeCafe.VasosGrande = vasosGrande;
        maquinaDeCafe.Azucarero = azucarero;
    }

    [Fact]
    public void GetTipoDeVaso_Pequeno_DevuelveVasoPequeno()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        Assert.Equal(maquinaDeCafe.VasosPequeno, vaso);
    }

    [Fact]
    public void GetTipoDeVaso_Mediano_DevuelveVasoMediano()
    {
        MaquinaDeCafe maquinaDeCafe = new MaquinaDeCafe();

        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");

        Assert.Equal(maquinaDeCafe.VasosMediano, vaso);
    }

    [Fact]
    public void GetTipoDeVaso_Grande_DevuelveVasoGrande()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");

        Assert.Equal(maquinaDeCafe.VasosGrande, vaso);
    }

    [Fact]
    public void GetVasoDeCafe_PideMasVasosDeLosQueHay_DevuelveNoHayVasos()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);

        Assert.Equal("No hay Vasos", resultado);
    }

    [Fact]
    public void GetVasoDeCafe_CafeInsuficiente_DevuelveNoHayCafe()
    {
        cafetera = new Cafetera(5);
        maquinaDeCafe.Cafetera = cafetera;

        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);

        Assert.Equal("No hay Cafe", resultado);
    }

    [Fact]
    public void GetVasoDeCafe_AzucarInsuficiente_DevuelveNoHayAzucar()
    {
        azucarero = new Azucarero(2);
        maquinaDeCafe.Azucarero = azucarero;

        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("No hay Azucar", resultado);
    }

    [Fact]
    public void GetVasoDeCafe_Servido_RestaCafe()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.Cafetera.CantidadCafe;

        Assert.Equal(40, resultado);
    }

    [Fact]
    public void GetVasoDeCafe_Servido_RestaVaso()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.VasosPequeno.CantidadVasos;

        Assert.Equal(4, resultado);
    }

    [Fact]
    public void GetVasoDeCafe_Servido_RestaAzucar()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.Azucarero.CantidadAzucar;

        Assert.Equal(17, resultado);
    }

    [Fact]
    public void GetVasoDeCafe_HayTodo_DevuelveFelicitaciones()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("Felicitaciones", resultado);
    }
}
