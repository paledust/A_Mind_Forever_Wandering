using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour 
{
    public InputField inputField;
    GameController controller;
    bool IF_ReadyToEnd;

    void Awake()
    {
		Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<GameController> ();
        inputField.onEndEdit.AddListener (AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        controller.LogStringWithReturn ("> " + userInput);
        userInput = userInput.ToLower ();

        if(IF_ReadyToEnd){
            Handle_Exit(userInput);
            return;
        }
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            InputComplete ();
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            controller.LogStringWithReturn("Does Perry Simm want to stop?(Y/N)");
            IF_ReadyToEnd = true;
            InputComplete ();
            return;
        }
        if(userInput == ""){
            controller.LogStringWithReturn("He doesn't know what to do.");
            InputComplete();
            return;
        }


        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split (delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++) 
        {
            InputAction inputAction = controller.inputActions [i];
            if (inputAction.keyWord == separatedInputWords [0]) 
            {
                inputAction.RespondToInput (controller, separatedInputWords);
                InputComplete ();
                return;
            }
        }
        controller.LogStringWithReturn("He doesn't know what " + "\"" + separatedInputWords[0] + "\"" + " means");
        InputComplete();
        return;

    }

    void InputComplete()
    {
        controller.DisplayLoggedText ();
        inputField.ActivateInputField ();
        inputField.text = null;
    }
    void Handle_Exit(string answer){
        if(answer == "y"){
            controller.QuitTheGame();
            return;
        }
        if(answer == "n"){
            IF_ReadyToEnd = false;
            InputComplete();
        }
    }
    void OnValueChanged(string input){
        if(IF_ReadyToEnd){
            if(input != "y" && input != "n"){
                inputField.text = null;
            }
        }
    }
}