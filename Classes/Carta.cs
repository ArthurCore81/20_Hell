namespace VinteUm.Classes
{
    public class Carta
    {
        public enum NaipeEnum
        {
            Paus = 1,
            Ouros = 2,
            Copas = 3,
            Espadas = 4
        }
        public required int Valor { get; set; }
        public required NaipeEnum Naipe { get; set; }

        public static List<Carta> Baralho { get; set; } = new List<Carta>();

        public static void CriarBaralho()
        {
            Baralho.Clear();
            NaipeEnum[] naipes = { NaipeEnum.Copas, NaipeEnum.Ouros, NaipeEnum.Espadas, NaipeEnum.Paus };
            for (int valor = 1; valor <= 13; valor++)
            {
                foreach (var naipe in naipes)
                {
                    int valorCarta = (valor > 10) ? 10 : valor; // As cartas J, Q e K valem 10
                    Baralho.Add(new Carta { Valor = valorCarta, Naipe = naipe });
                }
            }
            Embaralhar();
        }
        public static void Embaralhar()
        {
            Random random = new Random();
            int n = Baralho.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Carta value = Baralho[k];
                Baralho[k] = Baralho[n];
                Baralho[n] = value;
            }
        }

        public static Carta ComprarCarta()
        {
            Carta carta = Baralho[0];
            Baralho.RemoveAt(0);

            return carta;
        }
    }
}
