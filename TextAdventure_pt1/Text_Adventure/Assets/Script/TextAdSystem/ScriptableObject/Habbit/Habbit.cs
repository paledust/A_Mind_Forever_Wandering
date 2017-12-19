using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habbit : ScriptableObject {
	public Clock clock;
	public ActionResponse actionResponse;
	[TextArea]
	public string InHabbitDescription;
}
