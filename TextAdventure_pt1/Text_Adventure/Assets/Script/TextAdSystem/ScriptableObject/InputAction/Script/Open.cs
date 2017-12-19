using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="TextAdventure/InputActions/Open")]
public class Open : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		int num = separatedInputWords.Length;
		switch(num){
			case 1:
				controller.LogStringWithReturn("What does he want to unlock?");
				return;
			case 2:
				if(separatedInputWords[1] == "door"){
					if(controller.roomNavigation.TryUnlockDoor()){
						controller.LogStringWithReturn("The door is open.");
						return;
					}
				}

				controller.ReplyToNoneSense();
				return;
			default:
				controller.LogStringWithReturn("That sentence isn't one he recognize.");
				return;
		}
	}
}
