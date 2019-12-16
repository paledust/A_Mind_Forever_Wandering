using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePersons : MonoBehaviour {
	GameController controller;
	public RoomNavigation roomNavigation{get; private set;}
	public List<Person> PersonList;
	private List<string> _personInCurrentRoom = new List<string>();
	public List<string> PersonInCurrentRoom{get{return _personInCurrentRoom;}}
	TimeCounting timeCounting;
	void Start(){
		timeCounting = FindObjectOfType<TimeCounting>();
		roomNavigation = GetComponent<RoomNavigation>();
		controller = GetComponent<GameController>();
	}
	void FixedUpdate(){
		foreach(Person _person in PersonList){
			for(int i = 0;i<_person.habbits.Length;i++){
				if(CheckHabbit(_person.habbits[i]) && _person.currentHabbit != _person.habbits[i]){
					UnPackHabbit(_person, _person.habbits[i]);
				}
			}
		}
	}
	bool CheckHabbit(Habbit habbit){
		if(habbit.ActTime == timeCounting.ReturnTimeIn24()){
			return true;
		}
		return false;
	}
	public void UnPackHabbit(Person _person, Habbit habbit){
		_person.currentHabbit = habbit;
		
		if(_person.currentHabbit.Action != null){
			_person.currentHabbit.Action.DoHabbit(controller);
		}
	}
	public void ClearCollections(){
		_personInCurrentRoom.Clear();
	}
	public string GetPersonInThisRoom(Room ThisRoom, int i){
		Person interactableInRoom = ThisRoom.PersonInRoom[i];

		return ThisRoom.PersonInRoom[i].currentHabbit.InHabbitDescription;
	}
	public Room FindRoomThePersonIn(Person _person){
		return roomNavigation.RoomList.Find(x=>x.PersonInRoom.Contains(_person));
	}

}
