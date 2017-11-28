using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject {
	[SerializeField] string _noun = "name";
	public string noun{get{return _noun;}}
	[TextArea]
	[SerializeField] string _description = "Description in room";
	public string description{get{return _description;}}

	// Use this for initialization
	void Start () {
		
	}
}
