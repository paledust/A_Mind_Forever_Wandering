using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Clock {
	public int Hour;
	public int Min;
#region Redefine Comparision
	public override bool Equals(object Obj){
		Clock other = (Clock)Obj;
		return (this.Min == other.Min &&
			this.Hour == other.Hour);
	}
	public override int GetHashCode(){
		return this.Hour*10 + this.Min;
	}
	public static bool operator ==(Clock clock_1, Clock clock_2){
		return (clock_1.Min == clock_2.Min && clock_1.Hour == clock_2.Hour);
	}
	public static bool operator !=(Clock clock_1, Clock clock_2){
		return (clock_1.Min != clock_2.Min || clock_1.Hour != clock_2.Hour);
	}
#endregion
}
