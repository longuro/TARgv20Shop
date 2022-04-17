using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targv20Shop.Core.Dtos.Weather
{
    public class WeatherResultDto
    {
        //[JsonProperty("EffectiveDate")]
        public string EffectiveDate { get; set; }

        //[JsonProperty("EffectiveEpochDate")]
        public Int64 EffectiveEpochDate { get; set; }

        //[JsonProperty("Severity")]
        public int Severity { get; set; }

        //[JsonProperty("Text")]
        public string Text { get; set; }

        //[JsonProperty("Category")]
        public string Category { get; set; }

        //[JsonProperty("EndDate")]
        public string EndDate { get; set; }

        //[JsonProperty("EndEpochDate")]
        public Int64 EndEpochDate { get; set; }

        //[JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        //[JsonProperty("Link")]
        public string Link { get; set; }

        //[JsonProperty("Date")]
        public string Date { get; set; }

        //[JsonProperty("EpochDate")]
        public Int64 EpochDate { get; set; }

        //[JsonProperty("TempMinValue")]
        public double TempMinValue { get; set; }

        //[JsonProperty("TempMinUnit")]
        public string TempMinUnit { get; set; }

        //[JsonProperty("TempMinUnitType")]
        public int TempMinUnitType { get; set; }


        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }
        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }
        //public string DayPrecipitationType { get; set; }
        //public string DayPrecipitationIntensity { get; set; }
        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }
        //public string NightPrecipitationType { get; set; }
        //public string NightPrecipitationIntensity { get; set; }
    }
}
