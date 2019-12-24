using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit
{
    public string keyString;
    public string exitDescription;
    public int TimeToTake;
    public Room valueRoom;
}

[System.Serializable]
public class ExitWithDoor: Exit{
    public Door connectedDoor;
    public bool IF_Locked{get{return connectedDoor.IF_Locked;}}
    public void UnlockDoor(){
        connectedDoor.UnlockDoor();
    }
    public void LockDoor(){
        connectedDoor.LockDoor();
    }
}