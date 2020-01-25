using UnityEngine;
using UnityEngine.UI;

public class BalanceManager : MonoBehaviour{
    public SamCondition samCondition;
    [SerializeField] Text text;
    public string String_Balance{get; protected set;}
    string String_balancePercentage;
    // Start is called before the first frame update
    void Start(){
        String_balancePercentage = Mathf.FloorToInt(samCondition.Balance).ToString();
        CompleteBalance();
        text.text = String_Balance;
    }

    // Update is called once per frame
    void Update(){
        String_balancePercentage = Mathf.FloorToInt(samCondition.Balance).ToString();
        CompleteBalance();
        text.text = String_Balance;
    }
    protected void CompleteBalance(){
        String_Balance = "Balance:" + String_balancePercentage+"%";
    }
}
