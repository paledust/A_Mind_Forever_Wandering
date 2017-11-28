using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject 
{
    [SerializeField] string _keyWord;
    public string keyWord{get{return _keyWord;}}

    public abstract void RespondToInput (GameController controller, string[] separatedInputWords);
}