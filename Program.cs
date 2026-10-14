using VinteUm.Classes;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao 20_Hell");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Jogar");
        Console.WriteLine("2 - Como jogar");
        string? opcao = Console.ReadLine();
        switch (opcao)
        {
            case "1":
                Interface.IniciarJogo();
                break;
            case "2":
                Interface.ComoJogar();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                Main(args);
                break;
        }
    }
}
