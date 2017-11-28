using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject 
{
    [TextArea]
    [SerializeField] string _description;
    public string description{get{return _description;}}
    [SerializeField] string _roomName;
    public string roomName{get{return _roomName;}}
    [SerializeField] Exit[] _exits;
    public Exit[] exits{get{return _exits;}}
    [SerializeField] InteractableObject[] _interactableObjectsInRoom;
    public InteractableObject[] interactableObjectsInRoom{get{return _interactableObjectsInRoom;}}
}