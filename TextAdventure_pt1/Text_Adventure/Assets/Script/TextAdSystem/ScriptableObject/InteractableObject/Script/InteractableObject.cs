using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject {
	[SerializeField] protected string _noun = "name";
	public string noun{get{return _noun;}}
	[TextArea]
	[SerializeField] protected string _description = "Description in room";
	public string description{get{return _description;}}
	public Interaction[] interactions;
}
