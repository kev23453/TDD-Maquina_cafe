using Xunit;

namespace MaquinaCafe.Tests;

public class CafeteraTests
{
    [Fact]
    public void HasCafe_ExisteCafe_DevuelveVerdadero()
    {
        Cafetera cafetera = new Cafetera(10);

        bool resultado = cafetera.HasCafe(5);

        Assert.True(resultado);
    }

    [Fact]
    public void HasCafe_NoExisteCafe_DevuelveFalso()
    {
        Cafetera cafetera = new Cafetera(10);

        bool resultado = cafetera.HasCafe(11);

        Assert.False(resultado);
    }

    [Fact]
    public void GiveCafe_SieteDeDiez_QuedanTres()
    {
        Cafetera cafetera = new Cafetera(10);

        cafetera.GiveCafe(7);

        Assert.Equal(3, cafetera.CantidadCafe);
    }
}
