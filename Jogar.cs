using System;
using VinteUm.Classes;

public class Jogar
{
    private Jogador jogador;
    private Dealer dealer;
    private Carta carta;
    public void Iniciar(string nome)
    {
        Carta.CriarBaralho();
        dealer = new Dealer();
        dealer.MaoInicial();
        jogador = new Jogador(nome);
        jogador.MaoInicial();
        jogador.MostrarMao();
    }

    public void Comprar()
    {
        carta = Carta.ComprarCarta();
        jogador.ReceberCarta(carta);
        jogador.MostrarMao();
        jogador.Kabum();
        if (jogador.Pontuacao == 21)
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
        Console.WriteLine("É a vez do Dealer agora.");
        dealer.VezDoDealer();
        if (dealer.Pontuacao >= 17 && dealer.Pontuacao <= 21 && dealer.Pontuacao > jogador.Pontuacao)
        {
            Console.WriteLine($"Dealer venceu obiviamente, com {dealer.Pontuacao} pontos. Você perdeu, mas continue jogando até perder tudo!");
        }
        else if (dealer.Pontuacao >= 17 && dealer.Pontuacao <= 21 && dealer.Pontuacao < jogador.Pontuacao)
        {
            Console.WriteLine($"Você venceu? Isso não está certo você tinha {jogador.Pontuacao} pontos e o Dealer tinha {dealer.Pontuacao} pontos ... Mas que incopentente, jogue de novo, por favor :)");
        }
        else if (dealer.Pontuacao == jogador.Pontuacao)
        {
            Console.WriteLine($"Empate? Isso não está certo... Voce tem {jogador.Pontuacao} pontos e o Dealer tem {dealer.Pontuacao} pontos  e o dealer tem {dealer.Pontuacao} pontos... Vamos resolver isso");
            Desempate();
        }

    }

    public void Desempate()
    {
        if (dealer.CalcularValorNaipe() > jogador.CalcularValorNaipe())
        {
            Console.WriteLine($"Dealer venceu obviamente, com {dealer.CalcularValorNaipe()} pontos e você tinha {jogador.CalcularValorNaipe()} pontos. mas continue jogando você chegou bem perto!");
        }
        else if (dealer.CalcularValorNaipe() < jogador.CalcularValorNaipe())
        {
            Console.WriteLine($"Você venceu? Deixa eu ver isso direito, você tinha {jogador.CalcularValorNaipe()} pontos e o Dealer tinha {dealer.CalcularValorNaipe()} pontos... A incompetencia dele não tem limite. Jogue de novo, por favor :)");
        }
        else
        {
            Console.WriteLine($"Vamos ver, você tem {jogador.CalcularValorNaipe()} pontos e o Dealer tem {dealer.CalcularValorNaipe()} pontos... ");
            Console.WriteLine($"Empate? DE NOVO? Quais são as chances? Vou ter que arrumar outro jeito, pera ai... CARA ou COROA? Digite 1 para CARA e 2 para COROA");
            int escolha = Convert.ToInt32(Console.ReadLine());
            while ( (escolha != 1) && (escolha != 2))
            {
                Console.WriteLine("Opção inválida. Digite 1 para CARA e 2 para COROA");
                escolha = Convert.ToInt32(Console.ReadLine());
            }
            Random random = new Random();
            int resultado = random.Next(1, 11); // Gera um número aleatório entre 1 e 10
            if (escolha == resultado)
            {
                Console.WriteLine($"Você venceu?... Bom, dessa vez não foi nem culpa do Dealer, você é muito sortudo");
            }
            else
            {
                Console.WriteLine($"Dealer venceu obviamente! Você quase venceu trapaceando, mas não foi dessa vez. Jogue de novo, por favor :)");
            }
        }
    }
    public int PontuacaoJogador()
    {
        return jogador.Pontuacao;
    }
}