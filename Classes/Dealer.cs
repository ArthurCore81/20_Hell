namespace VinteUm.Classes
{
    public class Dealer : Participante
    { 
        public void MaoInicial()
        {
            for (int i = 0; i < 2; i++)
            {
                Carta carta = Carta.Baralho[0];
                Carta.Baralho.RemoveAt(0);
                ReceberCarta(carta);
                // ReceberCarta(carta);
                if( i ==  0){
                    Console.WriteLine($"Dealer recebeu a carta: {carta.Valor} de {carta.Naipe}");
                }
                else
                {
                    Console.WriteLine("Dealer recebeu uma carta virada para baixo.");
                }  
            }
        }

        public void MostrarMaoD()
        {
            Console.WriteLine($"A carta do Dealer é:");
            Console.WriteLine($"- {Mao[0].Valor} de {Mao[0].Naipe}");
        }

        public void VezDoDealer()
        {
            Console.WriteLine($"As cartas do Dealer são:"); 
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"- {Mao[i].Valor} de {Mao[i].Naipe}");
            }
            while (Pontuacao < 17)
            {
                Carta cartaComprada = Carta.ComprarCarta();
                ReceberCarta(cartaComprada);
                Console.WriteLine($"Dealer comprou a carta: {cartaComprada.Valor} de {cartaComprada.Naipe}");
            }
            if (Pontuacao > 21)
            {
                Console.WriteLine("Dealer estourou! Esse incopetente, você ganhou! Mas jogue de novo e per... tente ganhar mais");
            }
        }
    }
}