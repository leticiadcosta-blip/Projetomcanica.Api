namespace Projetomecanica.Api.Models
{
    public class Agendamento
    {
       public int Id { get; set; }
       public DateTime Data { get; set; }
       public string Servico { get; set; }
       public int VeiculoId { get;set; }
                

    }
}
