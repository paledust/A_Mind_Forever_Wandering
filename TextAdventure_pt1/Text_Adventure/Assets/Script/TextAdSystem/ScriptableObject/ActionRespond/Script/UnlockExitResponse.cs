using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockExitResponse : ActionResponse {
	public Door Required_Door;
	public override bool DoActionResponse(GameController controller){
		return false;
	}
}
