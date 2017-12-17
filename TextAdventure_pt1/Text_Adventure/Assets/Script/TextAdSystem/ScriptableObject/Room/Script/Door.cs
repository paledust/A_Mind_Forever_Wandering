using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/Door")]
public class Door : ScriptableObject {
	public string noun;
	[TextArea]
	[SerializeField] protected string Open_description = "Description when door is Open";
	[TextArea]
	[SerializeField] protected string Close_description = "Description when door is closed";
	public bool IF_Locked;
	public Interaction[] interactions;
	public void UnlockDoor(){
		IF_Locked = false;
	}
	public void LockDoor(){
		IF_Locked = true;
	}
}
