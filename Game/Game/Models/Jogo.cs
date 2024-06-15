namespace Game.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Estudio { get; set; }

        public Jogo(string nome, string genero, string estudio)
        {
            Nome = nome;
            Genero = genero;
            Estudio = estudio;
        }
    }
}
