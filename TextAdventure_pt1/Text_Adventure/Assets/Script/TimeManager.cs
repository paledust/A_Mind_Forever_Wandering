using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
	public static int WorldTime{get; protected set;}
	private static bool StartCounting = false;
	private static int newTime;
	// Use this for initialization
	void Start () {
		WorldTime = 0;
		StartCounting = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		WorldTime += 10 ;
		if(StartCounting && WorldTime >= newTime){
			StartCounting = false;
			Time.timeScale = 1;
		}
	}
	public static void SpeedUpTime(int mins = 10){
		newTime = WorldTime + mins*60;
		Time.timeScale = 100;
		StartCounting = true;
	}
}
