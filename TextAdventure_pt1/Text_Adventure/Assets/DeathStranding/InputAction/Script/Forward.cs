using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "TextAdventure/InputActions/Forward")]
public class Forward : InputAction
{
    public override void RespondToInput (GameController controller, string[] separatedInputWords)
    {
        GameController_DeathStranding controller_DS = controller as GameController_DeathStranding;
        if(controller_DS.Travelling) {
            controller_DS.LogStringWithReturn("You are already moving towards destination!");
			return;
        }

        if(separatedInputWords.Length == 1){
            if(controller_DS.roomNavigation.destination==null){
                controller_DS.LogStringWithReturn("You don't have a destination yet!");
                return;
            }
			controller_DS.LogStringWithDestination("You start moving towards ");
			controller_DS.ContinueTravelling();
		}
		else{
			controller.LogStringWithReturn("You don't know the word" + "\"" + separatedInputWords[1] + "\"");
		}
    }
}
