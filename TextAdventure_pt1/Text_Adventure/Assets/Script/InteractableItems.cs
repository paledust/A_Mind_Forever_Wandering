using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {
	[SerializeField] List<string> _nounsInRoom = new List<string>();
	public List<string> nounsInRoom{get{return _nounsInRoom;}}
	List<string> nounsInInventory = new List<string>();
	public string GetObjectNotInInventory(Room currentRoom, int i){
		InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];
		if(!nounsInInventory.Contains(interactableInRoom.noun)){
			nounsInRoom.Add(interactableInRoom.noun);
			return interactableInRoom.description;
		}
		
		return null;
	}
}
