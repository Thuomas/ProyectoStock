using System.ComponentModel.DataAnnotations;
using Stock.Utils;

namespace Stock.Models;

public class Observacion
{
    public int Id { get; set; }

    public Equipos Equipo { get; set; }

    [Display(Name = "Version de firmware")]
    public int FirmwareVersion { get; set; }
    
    public string Grabador { set; get; }

    [Display(Name = "N° Serie Grabador")]
    public string NumSerieGrabador { get; set; }
    
    [Display(Name = "V(mm)/Amp")]
    public double Amp { get; set; }

    public int Bpm { get; set; }

    public string Simulador  { get; set; }

    [Display(Name = "N° Serie Simulador")]
    public int NumSerieSimulador { get; set; }

    [Display(Name = "Software de analisis")]
    public int SoftAnalisis { get; set; }

}
