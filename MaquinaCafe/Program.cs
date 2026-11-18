using System.Text;

namespace MaquinaCafe;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MaquinaDeCafe maquina = CrearMaquina();

        Console.WriteLine("=== Máquina de café ===");
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1) Vaso pequeño (3 oz)");
            Console.WriteLine("2) Vaso mediano (5 oz)");
            Console.WriteLine("3) Vaso grande (7 oz)");
            Console.WriteLine("0) Salir");
            Console.Write("Elija el tamaño del vaso: ");

            string opcion = Console.ReadLine();
            if (opcion == null || opcion.Trim() == "0")
            {
                break;
            }

            Vaso vaso = maquina.GetTipoDeVaso(TipoSegunOpcion(opcion.Trim()));
            if (vaso == null)
            {
                Console.WriteLine("Opción no válida.");
                continue;
            }

            Console.Write("Cucharadas de azúcar: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int cucharadas))
            {
                Console.WriteLine("Cantidad no válida.");
                continue;
            }

            string resultado = maquina.GetVasoDeCafe(vaso, 1, cucharadas);
            if (resultado == MaquinaDeCafe.MensajeExito)
            {
                Console.WriteLine(resultado + ": recoja su vaso de café.");
            }
            else
            {
                Console.WriteLine(resultado);
            }
        }
        Console.WriteLine("Hasta luego.");
    }

    private static MaquinaDeCafe CrearMaquina()
    {
        return new MaquinaDeCafe
        {
            VasosPequeno = new Vaso(5, 3),
            VasosMediano = new Vaso(5, 5),
            VasosGrande = new Vaso(5, 7),
            Cafetera = new Cafetera(50),
            Azucarero = new Azucarero(20)
        };
    }

    private static string TipoSegunOpcion(string opcion)
    {
        switch (opcion)
        {
            case "1":
                return MaquinaDeCafe.TipoPequeno;
            case "2":
                return MaquinaDeCafe.TipoMediano;
            case "3":
                return MaquinaDeCafe.TipoGrande;
            default:
                return "";
        }
    }
}
