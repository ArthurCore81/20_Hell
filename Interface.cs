using System;
using VinteUm.Classes;
public class Interface
    {
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
                        bool partidaEmAndamento = true;
                        while (jogo.PontuacaoJogador() < 21 && partidaEmAndamento)
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