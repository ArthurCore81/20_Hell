using System;
using VinteUm.Classes;
public class Interface
{
    public static void ComoJogar()
    {
        Console.Clear();
        Console.WriteLine("O objetivo do jogo é chegar o mais próximo possível de 21 pontos sem ultrapassá-lo.");
        Console.WriteLine("Cada carta tem um valor: as cartas de 2 a 10 valem seu valor nominal, as cartas J, Q e K valem 10 pontos, e o Ás pode valer 1 ou 11 pontos, dependendo da escolha do jogador, mas só na primeira compra.");
        Console.WriteLine("O jogador começa com duas cartas e pode escolher comprar mais cartas ou parar.");
        Console.WriteLine("Se a pontuação do jogador ultrapassar 21, ele perde automaticamente.");
        Console.WriteLine("Após o jogador parar, é a vez do dealer jogar. O dealer deve comprar cartas até atingir pelo menos 17 pontos.");
        Console.WriteLine("Se o dealer ultrapassar 21 pontos, o jogador vence. Caso contrário, vence quem tiver a maior pontuação sem ultrapassar 21.");
        Console.WriteLine("Se houver empate, o jogo será decidido pela soma dos valores de naipes das cartas.");
        Console.WriteLine("Os naipes têm a seguinte ordem de valor: Paus (♣) < Ouros (♦) < Copas (♥) < Espadas (♠).");
        Console.WriteLine("Se ainda houver empate, a casa tem otimos metódos totalmente justos para decidir o vencedor.");
        Console.WriteLine("Boa sorte!");
    }

    public static void IniciarJogo()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Olá Viti... Quer dizer, Jogador! Bem-vindo ao jogo de Blackjack!");
            string nome = PegarNome();
            Console.WriteLine($"Olá {nome}! Você tem mais de 18? (Digite 'sim' por favor :)");
            string? resposta = Console.ReadLine().ToLower();
            try
            {
                if (resposta == "sim" || resposta == "s")
                {
                    Console.WriteLine("Ótimo! Vamos começar o jogo!");
                    Jogar jogo = new Jogar(); 
                    jogo.Iniciar(nome);
                    bool resultadoContabilizado = false;
                    bool partidaEmAndamento = true;
                    while (jogo.PontuacaoJogador() < 21
                            && partidaEmAndamento
                            && !jogo.Vitoria.HasValue)
                    {
                        Console.WriteLine($"Sua pontuação atual é: {jogo.PontuacaoJogador()}");
                        Console.WriteLine("Escolha uma opção:");
                        Console.WriteLine("1 - Comprar carta");
                        Console.WriteLine("2 - Ver a carta do Dealer");
                        Console.WriteLine("3 - Ver suas cartas");
                        Console.WriteLine("4 - Parar");
                        string? opcao = Console.ReadLine();
                        switch (opcao)
                        {
                            case "1" :
                                jogo.Comprar();
                                break;
                            case "2" :
                                jogo.MostrarMaoD();
                                break;
                            case "3" :
                                jogo.MostrarMaoJ();
                                break;
                            case "4" :
                                jogo.Parar();
                                partidaEmAndamento = false;
                                break;
                        }
                        if (!resultadoContabilizado && jogo.Vitoria.HasValue)
                        {
                            resultadoContabilizado = true;

                            if (jogo.Vitoria.Value)
                            {
                                Console.WriteLine("Resultado: Vitória!");
                            }
                            else
                            {
                                Console.WriteLine("Resultado: Derrota!");
                            }
                        }
                    }
                    Console.WriteLine("Quer jogar de novo? (Digite 'sim' para continuar ou qualquer outra tecla para sair)");
                    string? respostaContinuar = Console.ReadLine().ToLower();
                    if (respostaContinuar != "sim" && respostaContinuar != "s")
                    {
                        Console.WriteLine("Volte quando tiver mais dinheiro, POBRE! :)");
                        continuar = false;
                    }  
                }
                else
                {
                    Console.WriteLine("Desculpe, você precisa ter mais de 18 anos para jogar.");
                    Console.WriteLine("Pressione qualquer tecla para sair...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                return;
            }
        }
    }
    
    public static string PegarNome()
    {
        Console.WriteLine("Digite o seu nome:");
        return Console.ReadLine() ?? "Jogador";
    }
}