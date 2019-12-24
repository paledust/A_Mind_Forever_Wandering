using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableConstructions : MonoBehaviour
{
    [SerializeField] List<Construction> _constructionList;
    public List<Construction> constructionList{get{return _constructionList;}}
    
}
