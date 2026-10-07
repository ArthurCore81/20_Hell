namespace VinteUm.Classes
{
    public class Participante
    {
        public List<Carta> Mao { get; set; } = new List<Carta>();
        public int Pontuacao
        {
            get { return CalcularPontuacao(); }
        }

        public void ReceberCarta(Carta carta)
        {
            Mao.Add(carta);
        }

        public int CalcularPontuacao()
        {
            int pontuacao = 0;
            foreach (var carta in Mao)
            {
                pontuacao += carta.Valor;
            }
            return pontuacao;
        }
        public int CalcularValorNaipe()
        {
            int valorNaipes = 0;

            foreach (Carta carta in Mao)
            {
                valorNaipes += (int)carta.Naipe;
            }

            return valorNaipes;
        }
    }
}