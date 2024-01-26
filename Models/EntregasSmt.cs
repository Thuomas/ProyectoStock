using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class EntregasSmt
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    public DateOnly Fecha { get; set; }

    public string Remito { get; set; }

    [Display(Name = "Orden de Trabajo")]
    public int OrdenTrabajoId { get; set; }

    public virtual Trabajo OrdenTrabajo { get; set; }

    public int Cantidad { get; set; }

    public int CantidadRestante { get; set; }
}
