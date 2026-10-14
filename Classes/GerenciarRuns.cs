
using System.Text.Json;
using System.Linq;

namespace VinteUm.Classes
{
    public class GerenciarRuns
    {
        private readonly string caminhoArquivo = "runs.json";

        public List<Run> ListarRuns()
        {
           if (!File.Exists(caminhoArquivo))
           {
               return new List<Run>();
           }
           string json = File.ReadAllText(caminhoArquivo);
           return JsonSerializer.Deserialize<List<Run>>(json)
                  ?? new List<Run>();
        }
        public Run? CarregarRun(int id)
        {
            List<Run> runs = ListarRuns();

            Run? runEncontrada = runs.Find(r => r.Id == id);

            return runEncontrada;
        }
        private void SalvarTodasRuns(List<Run> runs)
        {
            var opcoes = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(runs, opcoes);

            File.WriteAllText(caminhoArquivo, json);
        }


        public void SalvarRun(Run run)
        {
            List<Run> runs = ListarRuns();

            Run? runExistente = runs.Find(r => r.Id == run.Id);

            if (runExistente == null)
            {
                runs.Add(run);
            }
            else
            {
                runExistente.NomeJogador = run.NomeJogador;
                runExistente.Vitorias = run.Vitorias;
                runExistente.Derrotas = run.Derrotas;
            }

            SalvarTodasRuns(runs);
        }


        
        public Run IniciarRun(string nomeJogador)
        {
            List<Run> runs = ListarRuns();

            int novoId;

            if (runs.Count > 0)
            {
                novoId = runs.Max(r => r.Id) + 1;
            }
            else
            {
                novoId = 1;
            }

            Run novaRun = new Run
            {
                Id = novoId,
                NomeJogador = nomeJogador,
                Vitorias = 0,
                Derrotas = 0,
            };

            return novaRun;
        }

    }
}
