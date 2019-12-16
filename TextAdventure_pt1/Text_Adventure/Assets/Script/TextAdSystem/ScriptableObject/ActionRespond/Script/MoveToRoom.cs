using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/PersonalHabbit/MoveToRoom")]
public class MoveToRoom : PersonalHabbit {
	public Room roomToChangeTo;
	public override bool DoHabbit(GameController controller){
		if(controller.interactablePersons.PersonList.Contains(personToAct)){
			if(controller.roomNavigation.currentRoom.PersonInRoom.Contains(personToAct)){
				controller.LogStringWithReturn(ChangeHabbitDescription);
				controller.DisplayLoggedText();
			}
			if(!roomToChangeTo.PersonInRoom.Contains(personToAct)){
				Debug.Log("Change");
				controller.MovePersonToRoom(roomToChangeTo, personToAct);
			}
			return true;
		}
		return false;
	}
}
