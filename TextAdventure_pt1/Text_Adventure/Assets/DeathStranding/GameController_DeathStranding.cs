using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_DeathStranding : GameController{
    public int EstimateTimeChangeWeather;
[Header("Balance Affector")]
    public float BaseWalkingBalance = 20;
    public float RainingEffector = 10;
    protected SamCondition samCondition;
    protected WeatherManager weatherManager;
    protected override void Init(){
        base.Init();
        samCondition    = GetComponent<SamCondition>();
        weatherManager  = GetComponent<WeatherManager>();
        
        AddNewTimeToWeather();
    }
    protected void Update(){
        UpdateSamCondition_Balance();
    }
    protected override void FixedUpdate(){
        TestWeatherChange();
        FixedUpdateSamCondition_Stamina();
        FixedUpdateSamCondition_Balance();
        base.FixedUpdate();
    }
    public void StopTravelling(){
        Travelling = false;
        TimeManager.SpeedUpTimeScale(1);
    }
    public void ContinueTravelling(){
        Travelling = true;
        EstimateTimeToDestination = TimeManager.WorldTime + TimeLeftToDestination;
        TimeManager.SpeedUpTimeScale(10);
    }
    public void LogStringWithDestination(string stringToAdd){
        actionLog.Add(stringToAdd + roomNavigation.destination.roomName + "\n");
    }
    public void CheckingStatus(string checkObj){
        checkObj = checkObj.ToLower();
        string checkResult = "";
        if(string.Equals(checkObj, "self")||
           string.Equals(checkObj, "yourself")||
           string.Equals(checkObj, "body")||
           string.Equals(checkObj, "health")||
           string.Equals(checkObj, "bodycondition")){
            checkResult = samCondition.PrepareHealthReport();
        }
        else if(string.Equals(checkObj, "weather")){
            checkResult = weatherManager.WeatherReport();
            int timeToChange = EstimateTimeChangeWeather - TimeManager.WorldTime;
            timeToChange = timeToChange/(weatherManager.ReportPrecise*60);
            timeToChange = (timeToChange+1) * weatherManager.ReportPrecise;
            checkResult += timeToChange.ToString() + " minutes.";
        }
        else if(string.Equals(checkObj, "equipment")){
            checkResult = samCondition.PrepareEquipmeentReport();
        }
        else{
            checkResult = "You can't check it.";
        }

        LogStringWithReturn(checkResult);
    }
    void TestWeatherChange(){
        if(TimeManager.WorldTime >= EstimateTimeChangeWeather){
            Debug.Log("Weather Change");
            AddNewTimeToWeather();
            string weatherChange = weatherManager.WeatherChangeReport();
            LogStringWithReturn(weatherChange);
            DisplayLoggedText();
        }
    }
    void AddNewTimeToWeather(){
        EstimateTimeChangeWeather = TimeManager.WorldTime + weatherManager.ChangeWeather()*60;
    }
    void FixedUpdateSamCondition_Stamina(){
        if(Travelling){
            samCondition.Stamina -= samCondition.StaminaDrainningSpeed;
            samCondition.StaminaCap -= samCondition.StaminaCapDrainingSpeed;
            samCondition.StaminaCap = Mathf.Max(0, samCondition.StaminaCap);
        }
        else if(samCondition.Stamina<samCondition.StaminaCap){
            samCondition.Stamina += samCondition.StaminaRecoverSpeed * Time.deltaTime;
            samCondition.Stamina = Mathf.Clamp(samCondition.Stamina, 0, samCondition.StaminaCap);
        }
    }
    void FixedUpdateSamCondition_Balance(){
        if(Travelling && TimeManager.WorldTime%100 == 0){
            float rnd = Random.Range(0f,1f);
            samCondition.Balance -= rnd*(BaseWalkingBalance + (weatherManager.Rainning?RainingEffector:0));
        }
    }
    void UpdateSamCondition_Balance(){
        if(samCondition.Balance < 100){
            samCondition.Balance += samCondition.BalanceRecoverSpeed * Time.deltaTime;
            samCondition.Balance = Mathf.Clamp(samCondition.Balance, 0, samCondition.BalanceCap);
        }
    }

    void OnGUI(){
        GUILayout.Label("Time Left:"+TimeLeftToDestination);
    }

}
