using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public int EstimateTimeToDestination;
    public int TimeLeftToDestination{get; protected set;}

    [SerializeField] Text _displayText;
    public Text displayText{get{return _displayText;}}
    [SerializeField] InputAction[] _inputActions;
    public InputAction[] inputActions{get{return _inputActions;}}
    public RoomNavigation roomNavigation{get; private set;}
    public InteractableItems interactableItems{get; private set;}
    public InteractableConstructions interactableConstructions{get; private set;}
    public InteractablePersons interactablePersons{get; private set;}
    private List<string> _interactionDescriptionsInRoom = new List<string>();
    public List<string> interactionDescriptionsInRoom{get{return _interactionDescriptionsInRoom;}}
    public List<string> Nonesense_Reply;

    protected List<string> actionLog = new List<string>();
    public bool Travelling{get; protected set;}

    // Use this for initialization
    protected void Awake ()
    {
        Init();
    }
    protected virtual void Init(){
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation> (); 
        interactablePersons = GetComponent<InteractablePersons>();
        interactableConstructions = GetComponent<InteractableConstructions>();      
        Travelling = false;
    }

    protected void Start()
    {
        DisplayRoomText ();
        DisplayLoggedText ();
    }
    protected virtual void FixedUpdate(){
        if(Travelling){
            DestinationTimeTesting();
        }
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join ("\n", actionLog.ToArray ());

        _displayText.text = logAsText;
    }
    public void ReachRoom(){
        Travelling = false;
        DisplayRoomText();
        DisplayLoggedText();
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
        PreparePersonToInteract(roomNavigation.currentRoom);
    }
    protected void PrepareObjectToTakeOrExamine(Room currenRoom){
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
    protected void PreparePersonToInteract(Room currentRoom){
        for(int i = 0; i<currentRoom.PersonInRoom.Count; i++){
            string descriptionPersonInRoom = interactablePersons.GetPersonInThisRoom(currentRoom,i);
            _interactionDescriptionsInRoom.Add(descriptionPersonInRoom);
        }
    }
    protected void DestinationTimeTesting(){
        TimeLeftToDestination = Mathf.Max(0, EstimateTimeToDestination - TimeManager.WorldTime);
        if(TimeManager.WorldTime >= EstimateTimeToDestination){
            Debug.Log("ReachDestination");
            roomNavigation.ReachRooms();
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string,string> verbDictionary, string verb, string noun){
        if(verbDictionary.ContainsKey(noun)){
            return verbDictionary[noun];
        }

        return "He can't "+verb+" "+noun;
    }

    protected void ClearCollectionsForNewRoom()
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
	public void RemovePersonFromRoom(Room _room, Person _person){
        Debug.Assert(_room.PersonInRoom.Contains(_person));
        if(_room.PersonInRoom.Contains(_person)){
            _room.PersonInRoom.Remove(_person);
        }
		//Also need to display action log;
	}
	public void AddPersonToRoom(Room _room, Person _person){
        Debug.Assert(!_room.PersonInRoom.Contains(_person));
        if(!_room.PersonInRoom.Contains(_person)){
            _room.PersonInRoom.Add(_person);
        }
	}
    public void MovePersonToRoom(Room _room, Person _person){
        RemovePersonFromRoom(interactablePersons.FindRoomThePersonIn(_person),_person);
        AddPersonToRoom(_room, _person);
    }
    public void AddNewTimeToDestination(int NewTime){
        Travelling = true;
        EstimateTimeToDestination = TimeManager.WorldTime + NewTime*10;
    }
}