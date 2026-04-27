using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace TestPlayWriteProject5
{
    public class Organizzazione
    {
        [Name(name: "TotUO")]
        [Display(Name = "Numero totale di UO")]
        public string? TotUO { get; set; }

        [Name(name: "LivGer")]
        [Display(Name = "Livelli gerarchici")]
        public string? LivGer { get; set; }

        [Name(name: "UOruoloV")]
        [Display(Name = "Numero UO con ruolo vacante")]
        public string? UOruoloV { get; set; }

        [Name(name: "UOruoloI")]
        [Display(Name = "Numero UO con ruolo ad Interim")]
        public string? UOruoloI { get; set; }
    }
    public class Processi
    {
        [Name(name: "ProcCens")]
        [Display(Name = "Numero totale di processi censiti")]
        public string? ProcCens { get; set; }

        [Name(name: "ProcObStrat")]
        [Display(Name = "Numero processi collegati ad obiettivi strategici")]
        public string? ProcObStrat { get; set; }

        [Name(name: "ProcSemplif")]
        [Display(Name = "Numero processi oggetti di semplificazione")]
        public string? ProcSemplif { get; set; }

        [Name(name: "ProcAltreAmmin")]
        [Display(Name = "Numero processi che coinvolgono altre amministrazioni")]
        public string? ProcAltreAmmin { get; set; }

        [Name(name: "ProcPicchiStag")]
        [Display(Name = "Numero processi con picchi stagionali")]
        public string? ProcPicchiStag { get; set; }

        [Name(name: "ProcPresCont")]
        [Display(Name = "Numero processi con presidio continuativo")]
        public string? ProcPresCont { get; set; }

        [Name(name: "ProcCritic")]
        [Display(Name = "Numero processi che presentano criticità")]
        public string? ProcCritic { get; set; }

        [Name(name: "ProcAgile")]
        [Display(Name = "Numero processi con attività adatte alla modalità agile")]
        public string? ProcAgile { get; set; }

        [Name(name: "ProcEstern")]
        [Display(Name = "Numero processi con esternalizzazione")]
        public string? ProcEstern { get; set; }

        [Name(name: "LivelloDigit")]
        [Display(Name = "Livello medio di digitalizzazione dei processi")]
        public string? LivelloDigit { get; set; }
    }
    public class Profili
    {
        [Name(name: "ProfiliGest")]
        [Display(Name = "Numero totale di profili gestiti")]
        public string? ProfiliGest { get; set; }

        [Name(name: "ProfiliRuoloAdot")]
        [Display(Name = "Numero di profili di ruolo adottati")]
        public string? ProfiliRuoloAdot { get; set; }

        [Name(name: "ProfiliCens")]
        [Display(Name = "Numero di profili censiti ex novo")]
        public string? ProfiliCens { get; set; }
    }
}
