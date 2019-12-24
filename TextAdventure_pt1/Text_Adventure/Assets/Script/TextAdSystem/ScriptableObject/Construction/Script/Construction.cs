using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Construction")]
public class Construction : ScriptableObject{
    [SerializeField] protected string _noun = "construction";
    public string noun{get{return _noun;}}
    [TextArea]
    [SerializeField] protected string _description = "Description of this construction";
    public string description{get{return _description;}}
    public Interaction[] interactions;
}
