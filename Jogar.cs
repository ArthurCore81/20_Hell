
using System;
using VinteUm.Classes;

public class Jogar
{
    private Jogador jogador;
    private Dealer dealer;
    private Carta carta;

    // true = vitória; false = derrota; null = partida sem resultado.
    public bool? Vitoria { get; private set; }

    public void Iniciar(string nome)
    {
        Vitoria = null;

        Carta.CriarBaralho();

        dealer = new Dealer();
        dealer.MaoInicial();

        jogador = new Jogador(nome);
        jogador.MaoInicial();
        jogador.MostrarMao();

        // Trata resultados já definidos na mão inicial.
        if (jogador.Pontuacao > 21)
        {
            jogador.Kabum();
            Vitoria = false;
        }
        else if (jogador.Pontuacao == 21)
        {
            Console.WriteLine("Você fez 21, mas ainda não ganhou!");
            Parar();
        }
    }

    public void Comprar()
    {
        if (Vitoria.HasValue)
            return;

        carta = Carta.ComprarCarta();
        jogador.ReceberCarta(carta);
        jogador.MostrarMao();
        jogador.Kabum();

        if (jogador.Pontuacao > 21)
        {
            Vitoria = false;
        }
        else if (jogador.Pontuacao == 21)
        {
            Console.WriteLine("Você fez 21, mas ainda não ganhou!");
            Parar();
        }
    }

    public void MostrarMaoD()
    {
        dealer.MostrarMaoD();
    }

    public void MostrarMaoJ()
    {
        jogador.MostrarMao();
    }

    public void Parar()
    {
        if (Vitoria.HasValue)
            return;

        Console.WriteLine("É a vez do Dealer agora.");
        dealer.VezDoDealer();

        // O dealer estourou: vitória do jogador.
        if (dealer.Pontuacao > 21)
        {
            Vitoria = true;
        }
        // O jogador estourou: derrota.
        else if (jogador.Pontuacao > 21)
        {
            Vitoria = false;
        }
        // Dealer tem mais pontos.
        else if (dealer.Pontuacao > jogador.Pontuacao)
        {
            Console.WriteLine(
                $"Dealer venceu obviamente, com {dealer.Pontuacao} pontos. " +
                "Você perdeu, mas continue jogando até perder tudo!");
            Vitoria = false;
        }
        // Jogador tem mais pontos.
        else if (jogador.Pontuacao > dealer.Pontuacao)
        {
            Console.WriteLine(
                $"Você venceu? Isso não está certo! Você tinha " +
                $"{jogador.Pontuacao} pontos e o Dealer tinha " +
                $"{dealer.Pontuacao} pontos... É, parece que você ganhou mesmo, " +
                "mas que dealer incompetente. Jogue de novo, por favor :)");
            Vitoria = true;
        }
        // Pontuações iguais: desempate.
        else
        {
            Console.WriteLine(
                $"Empate? Isso não está certo... Você tem " +
                $"{jogador.Pontuacao} pontos e o Dealer tem " +
                $"{dealer.Pontuacao} pontos. Vamos resolver isso!");

            Desempate();
        }
    }

    public void Desempate()
    {
        int valorDealer = dealer.CalcularValorNaipe();
        int valorJogador = jogador.CalcularValorNaipe();

        if (valorDealer > valorJogador)
        {
            Console.WriteLine(
                $"Dealer venceu obviamente, com {valorDealer} pontos " +
                $"e você tinha {valorJogador} pontos. Mas continue jogando!");
            Vitoria = false;
        }
        else if (valorJogador > valorDealer)
        {
            Console.WriteLine(
                $"Você venceu? Deixa eu ver isso direito... " +
                $"Você tinha {valorJogador} pontos e o Dealer tinha " +
                $"{valorDealer} pontos. Você venceu!");
            Vitoria = true;
        }
        else
        {
            Console.WriteLine(
                $"Vamos ver, você tem {valorJogador} pontos e o Dealer " +
                $"tem {valorDealer} pontos...");

            Console.WriteLine(
                "Empate? DE NOVO? Quais são as chances? " +
                "CARA ou COROA? Digite 1 para CARA e 2 para COROA.");

            int escolha;

            while (true)
            {
                string? entrada = Console.ReadLine();

                if (int.TryParse(entrada, out escolha) &&
                    (escolha == 1 || escolha == 2))
                {
                    break;
                }

                Console.WriteLine(
                    "Opção inválida. Digite 1 para CARA e 2 para COROA.");
            }

            Random random = new Random();
            int resultado = random.Next(1, 11);

            if (escolha == resultado)
            {
                Console.WriteLine(
                    "Você venceu?... Bom, dessa vez não foi nem culpa " +
                    "do Dealer, você é muito sortudo!");
                Vitoria = true;
            }
            else
            {
                Console.WriteLine(
                    "Dealer venceu obviamente! Você quase venceu, " +
                    "mas não foi dessa vez. Jogue de novo, por favor :)");
                Vitoria = false;
            }
        }
    }

    public int PontuacaoJogador()
    {
        return jogador.Pontuacao;
    }
}
