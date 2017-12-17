using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="TextAdventure/InputActions/Wait")]
public class Wait : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		int num;
		if(separatedInputWords.Length == 1){
			TimeManager.SpeedUpTime();
		}
		else if(int.TryParse(separatedInputWords[1], out num)){
			if(num <= 100){
				TimeManager.SpeedUpTime(num);
			}
			else{
				controller.LogStringWithReturn("That's too long to wait.");
				return;
			}
		}
		else{
			controller.LogStringWithReturn("He doesn't know " + "\"" + separatedInputWords[1] + "\"");
			return;
		}

		controller.LogStringWithReturn("Time Passes...");
	}
}
