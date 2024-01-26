using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class EquiposFinalizados
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    public DateOnly Fecha { get; set; }

    [Display(Name = "Desde")]
    public string Desde { get; set; }

    [Display(Name = "Hasta")]
    public string Hasta { get; set; }

    [Display(Name = "Cantidad")]
    public int Cantidad { get; set; }

    [Display(Name = "Restante de la O/P")]
    public int Restante { get; set; }

    public int OrdenProduccionId { get; set; }

    public virtual Produccion OrdenProduccion { get; set; }
}
