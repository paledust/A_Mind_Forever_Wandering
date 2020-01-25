using UnityEngine;

[CreateAssetMenu(menuName= "TextAdventure/InputActions/Check")]
public class Check : InputAction{
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		if(separatedInputWords.Length > 1){
            (controller as GameController_DeathStranding).CheckingStatus(separatedInputWords[1]);
		}
		else{
			controller.LogStringWithReturn("Do you want to Check Weather, Body Condition, Equipment or Goods");
		}
	}
}
