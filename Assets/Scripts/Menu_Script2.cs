using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Script2 : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width - 140, 20, 100, 50), "Menu")) {
			Debug.Log ("ok");
			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
		}
	}
}
