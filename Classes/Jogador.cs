namespace VinteUm.Classes
{
    public class Jogador : Participante
    {
        public string Nome { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
        }

        public void MaoInicial()
        {
            for (int i = 0; i < 2; i++)
            {
                Carta carta = Carta.Baralho[0];
                Carta.Baralho.RemoveAt(0);
                ReceberCarta(carta);
                if( carta.Valor == 1)
                {
                    Console.WriteLine("Você recebeu um Ás! Deseja que ele valha 1 ou 11?");
                    int escolha = Convert.ToInt32(Console.ReadLine());
                    if (escolha == 11)
                    {
                        carta.Valor = 11;
                    }
                }
            }
        }
        public void MostrarMao()
        {
            Console.WriteLine($"{Nome} possui as seguintes cartas:");
            foreach (var carta in Mao)
            {
                Console.WriteLine($"- {carta.Valor} de {carta.Naipe}");
            }
        }


        public void Kabum()
        {
            if (Pontuacao > 21)
            {
                Console.WriteLine($"KABUM!!!! Você estourou PATO!, Perdeu tudo! Pontuação: " + Pontuacao);
            }
        }

    }
}