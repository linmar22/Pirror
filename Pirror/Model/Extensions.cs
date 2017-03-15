using Pirror.Model.Enums;

namespace Pirror.Model
{
    public static class Extensions
    {
        public static string AsString(this WeatherCode code)
        {
            switch (code)
            {
                //200	thunderstorm with light rain
                //201	thunderstorm with rain
                //202	thunderstorm with heavy rain
                //210	light thunderstorm
                //211	thunderstorm
                //212	heavy thunderstorm
                //221	ragged thunderstorm
                //230	thunderstorm with light drizzle
                //231	thunderstorm with drizzle
                //232	thunderstorm with heavy drizzle
                case WeatherCode.ThunderstormWithLightRain:
                    return "Thunderstorm with light rain";
                case WeatherCode.ThunderstormWithRain:
                    return "Thunderstorm with rain";
                case WeatherCode.ThunderstormWithHeavyRain:
                    return "Thunderstorm with heavy rain";
                case WeatherCode.LightThunderstorm:
                    return "Light thunderstorm";
                case WeatherCode.HeavyThunderstorm:
                    return "Heavy thunderstorm";
                case WeatherCode.RaggedThunderstorm:
                    return "Ragged thunderstorm";
                case WeatherCode.ThunderstormWithLightDrizzle:
                    return "Thunderstorm with light drizzle";
                case WeatherCode.ThunderstormWithDrizzle:
                    return "Thunderstorm with drizzle";
                case WeatherCode.ThunderstormWithHeavyDrizzle:
                    return "Thunderstorm with heavy drizzle";

                //300	light intensity drizzle
                //301	drizzle
                //302	heavy intensity drizzle
                //310	light intensity drizzle rain
                //311	drizzle rain
                //312	heavy intensity drizzle rain
                //313	shower rain and drizzle
                //314	heavy shower rain and drizzle
                //321	shower drizzle
                case WeatherCode.LightIntensityDrizzle:
                    return "Light intensity drizzle";
                case WeatherCode.Drizzle:
                    return "Drizzle";
                case WeatherCode.HeavyIntensityDrizzle:
                    return "Heavy intensity drizzle";
                case WeatherCode.LightIntensityDrizzleRain:
                    return "Light intensity drizzle rain";
                case WeatherCode.DrizzleRain:
                    return "Drizzle rain";
                case WeatherCode.HeavyIntensityDrizzleRain:
                    return "Heavy intensity drizzle rain";
                case WeatherCode.ShowerRainAndDrizzle:
                    return "Shower, rain and drizzle";
                case WeatherCode.HeavyShowerRainAndDrizzle:
                    return "Heavy shower, rain and drizzle";
                case WeatherCode.ShowerDrizzle:
                    return "Shower drizzle";

                //Group 5xx: Rain
                //500	light rain
                //501	moderate rain
                //502	heavy intensity rain
                //503	very heavy rain
                //504	extreme rain
                //511	freezing rain
                //520	light intensity shower rain
                //521	shower rain
                //522	heavy intensity shower rain
                //531	ragged shower rain
                case WeatherCode.LightRain:
                    return "Light rain";
                case WeatherCode.ModerateRain:
                    return "Moderate rain";
                case WeatherCode.HeavyIntensityRain:
                    return "Heavy intensity rain";
                case WeatherCode.VeryHeavyRain:
                    return "Very heavy rain";
                case WeatherCode.ExtremeRain:
                    return "Extreme rain";
                case WeatherCode.FreezingRain:
                    return "Freezing rain";
                case WeatherCode.LightIntensityShowerRain:
                    return "Light intensity shower rain";
                case WeatherCode.ShowerRain:
                    return "Shower rain";
                case WeatherCode.HeavyIntensityShowerRain:
                    return "Heavy intensity shower rain";
                case WeatherCode.RaggedShowerRain:
                    return "Ragged shower rain";

                //Group 6xx: Snow
                //600	light snow
                //601	snow
                //602	heavy snow
                //611	sleet
                //612	shower sleet
                //615	light rain and snow
                //616	rain and snow
                //620	light shower snow
                //621	shower snow
                //622	heavy shower snow
                case WeatherCode.LightSnow:
                    return "Light snow";
                case WeatherCode.Snow:
                    return "Snow";
                case WeatherCode.HeavySnow:
                    return "Heavy snow";
                case WeatherCode.Sleet:
                    return "Sleet";
                case WeatherCode.ShowerSleet:
                    return "Shower sleet";
                case WeatherCode.LightRainAndSnow:
                    return "Light rain and snow";
                case WeatherCode.RainAndSnow:
                    return "Rain and snow";
                case WeatherCode.LightShowerSnow:
                    return "Light shower and snow";
                case WeatherCode.ShowerSnow:
                    return "Shower snow";
                case WeatherCode.HeavyShowerSnow:
                    return "Heavy shower snow";

                //Group 7xx: Atmosphere
                //701	mist
                //711	smoke
                //721	haze
                //731	sand, dust whirls
                //741	fog
                //751	sand
                //761	dust
                //762	volcanic ash
                //771	squalls
                //781	tornado
                case WeatherCode.Mist:
                    return "Mist";
                case WeatherCode.Smoke:
                    return "Smoke";
                case WeatherCode.Haze:
                    return "Haze";
                case WeatherCode.SandDustWhirls:
                    return "Sand, dust whirls";
                case WeatherCode.Fog:
                    return "Fog";
                case WeatherCode.Sand:
                    return "Sand";
                case WeatherCode.Dust:
                    return "Dust";
                case WeatherCode.VolcanicAsh:
                    return "Volcanic ash";
                case WeatherCode.Squalls:
                    return "Squalls";
                case WeatherCode.AtmosphereTornado:
                    return "Tornado";

                //Group 800: Clear
                //800	clear sky
                case WeatherCode.ClearSky:
                    return "Clear sky";

                //Group 80x: Clouds
                //801	few clouds
                //802	scattered clouds
                //803	broken clouds
                //804	overcast clouds
                case WeatherCode.FewClouds:
                    return "Few clouds";
                case WeatherCode.ScatteredClouds:
                    return "Scattered clouds";
                case WeatherCode.BrokenClouds:
                    return "Broken clouds";
                case WeatherCode.OvercastClouds:
                    return "Overcast clouds";

                //Group 90x: Extreme
                //900	tornado
                //901	tropical storm
                //902	hurricane
                //903	cold
                //904	hot
                //905	windy
                //906	hail
                case WeatherCode.ExtremeTornado:
                    return "Tornado";
                case WeatherCode.TropicalStorm:
                    return "Tropical storm";
                case WeatherCode.Hurricane:
                    return "Hurricane";
                case WeatherCode.Cold:
                    return "Cold";
                case WeatherCode.Hot:
                    return "Hot";
                case WeatherCode.Windy:
                    return "Windy";
                case WeatherCode.Hail:
                    return "Hail";

                //Group 9xx: Additional
                //951	calm
                //952	light breeze
                //953	gentle breeze
                //954	moderate breeze
                //955	fresh breeze
                //956	strong breeze
                //957	high wind, near gale
                //958	gale
                //959	severe gale
                //960	storm
                //961	violent storm
                //962	hurricane
                case WeatherCode.Calm:
                    return "Calm";
                case WeatherCode.LightBreeze:
                    return "Light breeze";
                case WeatherCode.GentleBreeze:
                    return "Gentle breeze";
                case WeatherCode.ModerateBreeze:
                    return "Moderate breeze";
                case WeatherCode.FreshBreeze:
                    return "Fresh breeze";
                case WeatherCode.StrongBreeze:
                    return "Strong breeze";
                case WeatherCode.HighWindNearGale:
                    return "High wind, near hale";
                case WeatherCode.Storm:
                    return "Storm";
                case WeatherCode.ViolentStorm:
                    return "Violent storm";
                case WeatherCode.AdditionalHurricane:
                    return "Hurricane";

                default:
                    return "Unrecognized weather code";
            }
        }
    }
}
