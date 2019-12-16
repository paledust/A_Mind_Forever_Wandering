using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {
    public Room currentRoom;
    [SerializeField] List<Room> roomList;
    public List<Room> RoomList{get{return roomList;}}
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room> ();
    Dictionary<string, Exit> StringToExit = new Dictionary<string, Exit>();
    Door DoorInRoom;
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController> ();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++) 
        {
            StringToExit.Add(currentRoom.exits[i].keyString, currentRoom.exits[i]);
            exitDictionary.Add (currentRoom.exits [i].keyString, currentRoom.exits [i].valueRoom);
            if(currentRoom.exits [i].exitDescription != "")
                controller.interactionDescriptionsInRoom.Add (currentRoom.exits [i].exitDescription);
        }
        if(currentRoom.exitWithDoor.connectedDoor != null){
            exitDictionary.Add(currentRoom.exitWithDoor.keyString, currentRoom.exitWithDoor.valueRoom);
            DoorInRoom = currentRoom.exitWithDoor.connectedDoor;
        }

    }
    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey (directionNoun)) {
            //If this is a normal exit
            if(StringToExit.ContainsKey(directionNoun)){
                currentRoom = exitDictionary [directionNoun];
                controller.LogStringWithReturn ("He head off to the " + directionNoun);
                controller.DisplayRoomText ();
            }
            //If this is an exit with door
            else if(currentRoom.exitWithDoor.connectedDoor != null){
                if(!currentRoom.exitWithDoor.IF_Locked){
                    currentRoom = exitDictionary [directionNoun];
                    controller.LogStringWithReturn ("He head off to the " + directionNoun);
                    controller.DisplayRoomText ();
                }
                else{
                    controller.LogStringWithReturn ("The door is closed.");
                    controller.DisplayLoggedText();
                }
            }

        } else {
            controller.LogStringWithReturn ("There is no path to the " + directionNoun);
        }
    }
    public bool TryUnlockDoor(){
        if(DoorInRoom != null){
            DoorInRoom.UnlockDoor();
            return true;
        }
        return false;
    }
    public bool TryLockDoor(){
        if(DoorInRoom != null){
            DoorInRoom.LockDoor();
            return true;
        }
        return false;  
    }
    public void ClearExits()
    {
        exitDictionary.Clear ();
        StringToExit.Clear();
        DoorInRoom = null; 
    }
}