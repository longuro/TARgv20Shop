﻿using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos.Weather;
using Targv20Shop.Core.ServiceInterface;


namespace Targv20Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //string apikey = "nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y";
            //var Location = "Tallinn";
            // connection string
            //var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{Location}?apikey={idWeather}";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y&language=et-et&metric=true";

            using (WebClient client = new WebClient()) // WebClient
            {
                string json = client.DownloadString(url);
                //ainult ühe classi saab deserialiseerida
                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;

                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                //dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                //dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                //dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                //dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }

        WeatherResultDto IWeatherForecastServices.GetForecast(string city)
        {
            //string appKey = "nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y";
            // Connection String
            var client = new RestClient($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=nYHo7WQ7OamrCz4dwUB1TrKUXgFWVU7Y&metric=true");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResultDto>();
            }

            return null;
        }
    }
}