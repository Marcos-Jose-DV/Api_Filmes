namespace FilmesAPi.Data.Dtos;

public class ReadfilmeDto
{
  
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }   
    public string HoraDaConsulta { get; set; } = DateTime.Now.ToString("F");
}
