using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamCondition : MonoBehaviour
{
    public float BalanceCap = 100;
    public float StaminaCap = 100;
    [Range(0,100)]
    public float Balance = 100;
    [Range(0,100)]
    public float Health = 100;
    [Range(0,100)]
    public float Stamina = 100;
    [Range(0,100)]
    public float BootCondition = 100;
    public float BalanceRecoverSpeed = 20;
    public float StaminaCapDrainingSpeed = .1f;
    public float StaminaDrainningSpeed = 1;
    public float StaminaRecoverSpeed = 5;
    public float CarryWeight = 0;
    public string PrepareHealthReport(){
        string status = "";
        status = bloodLevel() + "\n" +
                 staminaLevel();
        return status;
    }
    public string PrepareEquipmeentReport(){
        string status = "";
        status = bootCondition();
        return status;
    }
    protected string bloodLevel(){
        if(Health >= 80) return "You are quite healthy.";
        else if(Health >= 50) return "You are slightly injured.";
        else if(Health >= 20) return "You are heavily injured.";
        else if(Health > 0) return "You are in Critical Danger.";
        else return "You are dead.";
    }
    protected string staminaLevel(){
        if(Stamina >= 80) return "You feel energetic.";
        else if(Stamina >= 50) return "You feel a bit tired.";
        else if(Stamina >= 20)return "You feel very tired.";
        else if(Stamina > 0)return "You feel exhausted";
        else return "You can't keep going anymore.";
    }
    protected string bootCondition(){
        if(BootCondition >= 80) return "Your shoes are new.";
        else if(BootCondition >= 50) return "Your shoes are a bit dirty.";
        else if(BootCondition >= 20)return "You shoes are worn.";
        else if(BootCondition > 0) return "Your shoes are nearly broken";
        return "Your shoes are completely worn out.";
    }
}
