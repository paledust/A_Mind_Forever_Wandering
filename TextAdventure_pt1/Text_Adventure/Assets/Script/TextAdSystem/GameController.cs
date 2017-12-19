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
    public List<string> Nonesense_Reply;

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

    public void QuitTheGame(){
        Application.Quit();
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom ();
        PrepareObjectToTakeOrExamine(roomNavigation.currentRoom);
    }
    void PrepareObjectToTakeOrExamine(Room currenRoom){
        for (int i = 0; i < currenRoom.interactableObjectsInRoom.Count; i++){
            string descriptionNotInInventory = interactableItems.GetObjectNotInInventory(currenRoom, i);
            if(descriptionNotInInventory != null){
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currenRoom.interactableObjectsInRoom[i];

            for(int j = 0; j<interactableInRoom.interactions.Length; j++){
                Interaction interaction = interactableInRoom.interactions[j];
                if(interaction.inputAction.keyWord == "examine"){
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
                if(interaction.inputAction.keyWord == "take"){
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
            }
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string,string> verbDictionary, string verb, string noun){
        if(verbDictionary.ContainsKey(noun)){
            return verbDictionary[noun];
        }

        return "He can't "+verb+" "+noun;
    }

    void ClearCollectionsForNewRoom()
    {
        _interactionDescriptionsInRoom.Clear ();
        interactableItems.ClearCollections();
        roomNavigation.ClearExits ();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add (stringToAdd + "\n");
    }
    public void ReplyToNoneSense(){
        int rnd = Random.Range(0, Nonesense_Reply.Count);

        LogStringWithReturn(Nonesense_Reply[rnd]);
    }
}