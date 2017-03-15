namespace Pirror.Model.Enums
{
    public enum WeatherCode
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
        
        ThunderstormWithLightRain = 200,
        ThunderstormWithRain = 201,
        ThunderstormWithHeavyRain = 202,
        LightThunderstorm = 210,
        Thunderstorm = 211,
        HeavyThunderstorm = 212,
        RaggedThunderstorm = 221,
        ThunderstormWithLightDrizzle = 230,
        ThunderstormWithDrizzle = 231,
        ThunderstormWithHeavyDrizzle = 232,

        //Group 3xx: Drizzle
        //300	light intensity drizzle
        //301	drizzle
        //302	heavy intensity drizzle
        //310	light intensity drizzle rain
        //311	drizzle rain
        //312	heavy intensity drizzle rain
        //313	shower rain and drizzle
        //314	heavy shower rain and drizzle
        //321	shower drizzle
        
        LightIntensityDrizzle = 300,
        Drizzle = 301,
        HeavyIntensityDrizzle= 302,
        LightIntensityDrizzleRain = 310,
        DrizzleRain = 311,
        HeavyIntensityDrizzleRain = 312,
        ShowerRainAndDrizzle = 313,
        HeavyShowerRainAndDrizzle = 314,
        ShowerDrizzle = 321,

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
        
        LightRain = 500,
        ModerateRain = 501,
        HeavyIntensityRain = 502,
        VeryHeavyRain = 503,
        ExtremeRain = 504,
        FreezingRain = 511,
        LightIntensityShowerRain = 520,
        ShowerRain = 521,
        HeavyIntensityShowerRain = 522,
        RaggedShowerRain = 531,

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

        LightSnow = 600,
        Snow = 601,
        HeavySnow = 602,
        Sleet = 611,
        ShowerSleet = 612,
        LightRainAndSnow = 615,
        RainAndSnow = 616,
        LightShowerSnow = 620,
        ShowerSnow = 621,
        HeavyShowerSnow = 622,

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

        Mist = 701,
        Smoke = 711,
        Haze = 721,
        SandDustWhirls = 731,
        Fog = 741,
        Sand = 751,
        Dust = 761,
        VolcanicAsh = 762,
        Squalls = 771,
        AtmosphereTornado = 781,

        //Group 800: Clear
        //800	clear sky
        
        ClearSky = 800,

        //Group 80x: Clouds
        //801	few clouds
        //802	scattered clouds
        //803	broken clouds
        //804	overcast clouds

        FewClouds = 801,
        ScatteredClouds = 802,
        BrokenClouds = 803,
        OvercastClouds = 804,

        //Group 90x: Extreme
        //900	tornado
        //901	tropical storm
        //902	hurricane
        //903	cold
        //904	hot
        //905	windy
        //906	hail
        
        ExtremeTornado = 900,
        TropicalStorm = 901,
        Hurricane = 902,
        Cold = 903,
        Hot = 904,
        Windy = 905,
        Hail = 906,

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

        Calm = 951,
        LightBreeze = 952,
        GentleBreeze = 953,
        ModerateBreeze = 954,
        FreshBreeze = 955,
        StrongBreeze = 956,
        HighWindNearGale = 957,
        Gale = 958,
        SevereGale = 959,
        Storm = 960,
        ViolentStorm = 961,
        AdditionalHurricane = 962

    }
}