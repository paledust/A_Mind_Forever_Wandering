using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Rooms/Room")]
public class Room : ScriptableObject 
{
    [TextArea]
    [SerializeField] string _description;
    public string description{get{return _description;}}
    [SerializeField] string _roomName;
    public string roomName{get{return _roomName;}}
    public Exit[] exits;
    public ExitWithDoor exitWithDoor;
    [SerializeField] List<InteractableObject> _interactableObjectsInRoom;
    public List<InteractableObject> interactableObjectsInRoom{get{return _interactableObjectsInRoom;}}
    public List<Person> PersonInRoom;
}