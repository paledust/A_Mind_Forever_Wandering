using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "TextAdventure/InputActions/Stop")]
public class Stop : InputAction
{
    public override void RespondToInput (GameController controller, string[] separatedInputWords)
    {
		GameController_DeathStranding controller_DS = controller as GameController_DeathStranding;
		if(!controller_DS.Travelling){
			controller_DS.LogStringWithReturn("You can only stop moving during travelling.");
			return;
		}
		if(separatedInputWords.Length == 1){ 
			controller_DS.LogStringWithDestination("You stop at the mid of the journey to ");
			controller_DS.StopTravelling();
		}
		else{
			controller.LogStringWithReturn("You don't know the word" + "\"" + separatedInputWords[1] + "\"");
		}
    }
}
