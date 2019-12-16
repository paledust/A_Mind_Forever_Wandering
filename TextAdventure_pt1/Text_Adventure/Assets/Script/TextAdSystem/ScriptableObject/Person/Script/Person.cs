using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Person")]
public class Person : ScriptableObject {
	public string noun = "name";
	public Habbit[] habbits;
	public Habbit currentHabbit;
	[TextArea]
	public string description;
	public Interaction[] interactions;
}
