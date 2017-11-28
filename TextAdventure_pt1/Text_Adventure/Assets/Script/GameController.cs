using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] Text _displayText;
    public Text displayText{get{return _displayText;}}
    [SerializeField] InputAction[] _inputActions;
    public InputAction[] inputActions{get{return _inputActions;}}
    public RoomNavigation roomNavigation{get; private set;}
    public InteractableItems interactableItems{get; private set;}
    private List<string> _interactionDescriptionsInRoom = new List<string>();
    public List<string> interactionDescriptionsInRoom{get{return _interactionDescriptionsInRoom;}}

    List<string> actionLog = new List<string>();

    // Use this for initialization
    void Awake () 
    {
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation> (); 
    }

    void Start()
    {
        DisplayRoomText ();
        DisplayLoggedText ();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join ("\n", actionLog.ToArray ());

        _displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom ();

        UnpackRoom ();

        string joinedInteractionDescriptions = string.Join ("\n", _interactionDescriptionsInRoom.ToArray ());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn (combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom ();
        PrepareObjectToTakeOrExamine(roomNavigation.currentRoom);
    }
    void PrepareObjectToTakeOrExamine(Room currenRoom){
        for (int i = 0; i < currenRoom.interactableObjectsInRoom.Length; i++){
            string descriptionNotInInventory = interactableItems.GetObjectNotInInventory(currenRoom, i);
            if(descriptionNotInInventory != null){
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }
        }
    }

    void ClearCollectionsForNewRoom()
    {
        _interactionDescriptionsInRoom.Clear ();
        roomNavigation.ClearExits ();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add (stringToAdd + "\n");
    }
}