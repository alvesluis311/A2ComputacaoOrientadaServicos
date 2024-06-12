namespace Game.Models
{
    public class Jogo
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Estudio { get; set; }

        public Jogo(string nome, string genero, string estudio)
        {
            Nome = nome;
            Genero = genero;
            Estudio = estudio;
        }

        // Método para exibir informações do jogo
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Gênero: {Genero}");
            Console.WriteLine($"Estúdio: {Estudio}");
        }
    }
}
