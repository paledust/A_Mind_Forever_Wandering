using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayLocation : MonoBehaviour {
	[SerializeField] Text text;
	RoomNavigation roomNavigation;
	// Use this for initialization
	void Start () {
		roomNavigation = FindObjectOfType<RoomNavigation>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Location: " + roomNavigation.currentRoom.roomName;
	}
}
