using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour 
{
    public InputField inputField;

    GameController controller;

    void Awake()
    {
		Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<GameController> ();
        inputField.onEndEdit.AddListener (AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        controller.LogStringWithReturn (userInput);
        userInput = userInput.ToLower ();

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split (delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++) 
        {
            InputAction inputAction = controller.inputActions [i];
            if (inputAction.keyWord == separatedInputWords [0]) 
            {
                inputAction.RespondToInput (controller, separatedInputWords);
            }
        }

        InputComplete ();

    }

    void InputComplete()
    {
        controller.DisplayLoggedText ();
        inputField.ActivateInputField ();
        inputField.text = null;
    }

}