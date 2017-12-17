using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PressAnyKeyToLoadLevel : MonoBehaviour {
	public string nextLevel;
	// Use this for initialization
	void Update(){
		if(Input.anyKeyDown){
			LoadLevel();
		}
	}
    void LoadLevel()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);

    }
}
