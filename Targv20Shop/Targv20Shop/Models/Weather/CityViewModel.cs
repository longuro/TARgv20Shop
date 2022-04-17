﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targv20Shop.Models.Weather
{
    public class CityViewModel
    {
        public string EffectiveDate { get; set; }
        public Int64 EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string EndDate { get; set; }
        public Int64 EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public string Date { get; set; }
        public Int64 EpochDate { get; set; }
        public double TempMinValue { get; set; }
        public string TempMinUnit { get; set; }
        public int TempMinUnitType { get; set; }
        public double TempMaxValue { get; set; }
        public string TempMaxUnit { get; set; }
        public int TempMaxUnitType { get; set; }
        public int DayIcon { get; set; }
        public string DayIconPhrase { get; set; }
        public bool DayHasPrecipitation { get; set; }
        public string DayPrecipitationType { get; set; }
        public string DayPrecipitationIntensity { get; set; }
        public int NightIcon { get; set; }
        public string NightIconPhrase { get; set; }
        public bool NightHasPrecipitation { get; set; }
        public string NightPrecipitationType { get; set; }
        public string NightPrecipitationIntensity { get; set; }
    }
}