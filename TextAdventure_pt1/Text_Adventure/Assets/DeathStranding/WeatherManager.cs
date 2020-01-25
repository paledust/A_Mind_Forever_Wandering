using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour{
    public int ReportPrecise = 5;
    public int MinIntersection = 10;
    public int MaxIntersection = 20;
    public bool Rainning = false;
    public int ChangeWeather(){
        Rainning = !Rainning;
        return Random.Range(MinIntersection, MaxIntersection);
    }
    public string WeatherChangeReport(){
        string report;
        if(Rainning){
            report = "The raining starts.";
            return report;
        }
        else{
            report = "The raining stops.";
            return report;
        }
    }
    public string WeatherReport(){
        string report;
        if(Rainning){
            report = "It is Raining. Estimated to be clear in the next ";
            return report;
        }
        else{
            report = "It is Foggy. Estimated to be raining in the next ";
            return report;
        }
    }
}
