using Xunit;

namespace MaquinaCafe.Tests;

public class AzucareroTests
{
    private readonly Azucarero azucarero;

    public AzucareroTests()
    {
        azucarero = new Azucarero(10);
    }

    [Fact]
    public void HasAzucar_HaySuficiente_DevuelveVerdadero()
    {
        bool resultado = azucarero.HasAzucar(5);

        Assert.True(resultado);

        resultado = azucarero.HasAzucar(10);

        Assert.True(resultado);
    }

    [Fact]
    public void HasAzucar_NoHaySuficiente_DevuelveFalso()
    {
        bool resultado = azucarero.HasAzucar(15);

        Assert.False(resultado);
    }

    [Fact]
    public void GiveAzucar_DosVeces_RestaLasCantidades()
    {
        azucarero.GiveAzucar(5);

        Assert.Equal(5, azucarero.CantidadAzucar);

        azucarero.GiveAzucar(2);

        Assert.Equal(3, azucarero.CantidadAzucar);
    }
}
