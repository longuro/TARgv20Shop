﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targv20Shop.Core.Dtos.Weather;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Models.Weather;

namespace Targv20Shop.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity vm = new SearchCity();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Weather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResultDto dto = new WeatherResultDto();

            var weatherResponse = _weatherForecastServices.WeatherDetail(dto);

            CityViewModel model = new CityViewModel();

            model.EffectiveDate = weatherResponse.Result.EffectiveDate;
            model.EffectiveEpochDate = weatherResponse.Result.EffectiveEpochDate;
            model.Severity = weatherResponse.Result.Severity;
            model.Text = weatherResponse.Result.Text;
            model.Category = weatherResponse.Result.Category;
            model.EndDate = weatherResponse.Result.EndDate;
            model.EndEpochDate = weatherResponse.Result.EndEpochDate;
            model.MobileLink = weatherResponse.Result.MobileLink;
            model.Link = weatherResponse.Result.Link;

            model.Date = dto.Date;
            model.EpochDate = dto.EpochDate;

            model.TempMinValue = dto.TempMinValue;
            model.TempMinUnit = dto.TempMinUnit;
            model.TempMinUnitType = dto.TempMinUnitType;

            model.TempMaxValue = dto.TempMaxValue;
            model.TempMaxUnit = dto.TempMaxUnit;
            model.TempMaxUnitType = dto.TempMaxUnitType;

            model.DayIcon = dto.DayIcon;
            model.DayIconPhrase = dto.DayIconPhrase;
            model.DayHasPrecipitation = dto.DayHasPrecipitation;

            model.NightIcon = dto.NightIcon;
            model.NightIconPhrase = dto.NightIconPhrase;
            model.NightHasPrecipitation = dto.NightHasPrecipitation;

            return View(model);
        }
    }
}
