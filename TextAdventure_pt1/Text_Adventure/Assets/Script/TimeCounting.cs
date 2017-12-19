using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCounting : MonoBehaviour {
	[Header("StartTime should be 12-hour mode")]
	[SerializeField] string StartTime;
	[SerializeField] Text text;
	public string String_Time{get; protected set;}
	string min_Time;
	string hr_Time;
	string alt_hr_time;
	string dayMark = "am";
	int timer;
	const float min = 60;
	// Use this for initialization
	void Start () {
		timer = 0;
		String_Time = StartTime;
		hr_Time = String_Time.Split(':')[0];
		min_Time = String_Time.Split(':')[1];
		transferTo12Hours();
		CompleteTime();
		text.text = String_Time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer = TimeManager.WorldTime;
		if(timer%60 == 0){
			AddMin();
			CompleteTime();
			text.text = String_Time;
		}
	}
	protected void AddMin(){
		int min = int.Parse(min_Time);
		min ++;
		if(min == 60){
			min = 0;
			min_Time = "00";
			AddHour();
		}
		else{
			if(min < 10){
				min_Time = "0" + min.ToString();
			}
			else{
				min_Time = min.ToString();
			}
		}
		
	}
	protected void AddHour(){
		int hour = int.Parse(hr_Time);
		hour ++;

		if(hour == 24){
			hour = 0;
			hr_Time = "00";
		}
		else{
			if(hour < 10){
				hr_Time = "0" + hour.ToString();
			}
			else{
				hr_Time = hour.ToString();
			}
		}

		transferTo12Hours();
	}
	protected void transferTo12Hours(){
		alt_hr_time = hr_Time;
		int hour = int.Parse(alt_hr_time);
		if(hour == 0){
			dayMark = "am";
			alt_hr_time = "00";
		}
		else if(hour >= 12){
			dayMark ="pm";
			if(hour > 12){
				hour -= 12;
				if(hour < 10){
					alt_hr_time = "0" + hour.ToString();
				}
				else{
					alt_hr_time = hour.ToString();
				}
			}
		}
	}
	protected void CompleteTime(){
		String_Time = alt_hr_time + ":" + min_Time + dayMark;
		String_Time = "Time: " + String_Time;
	}
	public void DisableThis(){
		enabled = false;
	}
	public Clock ReturnTimeIn24(){
		Clock clock = new Clock();
		
		clock.Hour = int.Parse(hr_Time);
		clock.Min = int.Parse(min_Time);

		return clock;
	}
}
