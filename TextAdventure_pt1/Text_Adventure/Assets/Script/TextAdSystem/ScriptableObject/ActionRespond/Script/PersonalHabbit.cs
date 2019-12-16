using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonalHabbit : ScriptableObject {
	public Person personToAct;
	[TextArea]
	public string ChangeHabbitDescription;
	public abstract bool DoHabbit(GameController controller);
}
