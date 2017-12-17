using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="TextAdventure/InputActions/Hello")]
public class Hello : InputAction {
	public override void RespondToInput(GameController controller, string[] separatedInputWords){
		if(separatedInputWords.Length == 1){
			controller.LogStringWithReturn("Talking to oneself is a sign of impending mental collapse.");
		}
		else{
			controller.LogStringWithReturn("He doesn't know the word" + "\"" + separatedInputWords[1] + "\"");
		}
	}
}
