using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class Produccion
{
    public int Id { get; set; }

    [Display(Name="Fecha")]
    public DateOnly Fecha { get; set; }

    [Display(Name="O/P")]
    public string OrdenProduccion { get; set; }

     [Display(Name="Equipo")]
     public Equipos Equipo {get; set;}

    public int Cantidad { get; set; }
    
    public virtual List<EquiposFinalizados> EquiposFinalizados { get; set; }
}