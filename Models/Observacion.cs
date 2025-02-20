using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class Observacion
{
    public int Id { get; set; }

    public int firmwareVersion { get; set; }

    public string grabador {set; get;}

    public string numSerieGrabador { get; set; }
    
    [Display(Name = "V(mm)/Amp")]
    public double amp { get; set; }

    public int bpm { get; set; }

    public string Simulador  { get; set; }

    public int NumSerieSimulador { get; set; }

    public int SoftAnalisis { get; set; }

    public int Cantidad { get; set; }

}
