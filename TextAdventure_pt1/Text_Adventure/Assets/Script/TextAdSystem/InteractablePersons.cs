using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePersons : MonoBehaviour {
	GameController controller;
	public RoomNavigation roomNavigation{get; private set;}
	public List<Person> PersonList;
	private List<string> _personInRoom = new List<string>();
	public List<string> PersonInRoom{get{return _personInRoom;}}
	TimeCounting timeCounting;
	void Start(){
		timeCounting = FindObjectOfType<TimeCounting>();
		roomNavigation = GetComponent<RoomNavigation>();

	}
	void FixedUpdate(){
		foreach(Person _person in PersonList){
			for(int i = 0;i<_person.habbits.Length;i++){
				if(CheckHabbit(_person.habbits[i])){
					Debug.Log("Say No");
				}
			}
		}
	}
	bool CheckHabbit(Habbit habbit){
		if(habbit.clock == timeCounting.ReturnTimeIn24()){
			return true;		
		}
		return false;
	}
	public void ClearCollections(){
		_personInRoom.Clear();
		PersonList.Clear();
	}
	public void RemovePersonFromRoom(Room _room, Person _person){
		_room.RemovePerson(_person);
		//Also need to display action log;
	}
	public void AddPersonToRoom(Room _room, Person _person){
		_room.AddPerson(_person);
	}
}
