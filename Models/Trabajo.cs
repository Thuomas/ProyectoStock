using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class Trabajo
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    public DateOnly Fecha { get; set; }

    [Display(Name="Orden de Trabajo nº")]
    public string OrdenTrabajo { get; set; }

    [Display(Name = "Equipo")]
    public Equipos Equipo { get; set; }

    public int Cantidad { get; set; }

    [Display(Name = "Orden de produccion")]
    public int OrdenProduccionId { get; set; }

    public virtual Produccion OrdenProduccion { get; set; }

    public virtual List<EntregasSmt> Entregas { get; set; }

}
