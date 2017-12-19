using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="TextAdventure/InputActions/Close")]
public class Close : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		int num = separatedInputWords.Length;
		switch(num){
			case 1:
				controller.LogStringWithReturn("What does he want to unlock?");
				return;
			case 2:
				if(separatedInputWords[1] == "door"){
					if(controller.roomNavigation.TryLockDoor()){
						controller.LogStringWithReturn("The door is closed.");
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
