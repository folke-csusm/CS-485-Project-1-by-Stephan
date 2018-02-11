using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu_Script : MonoBehaviour {


	public int buttonWid;
	public int buttonHeight;
	private int originpoint_x;
	private int originpoint_y;
	// Use this for initialization
	void Start () {
		buttonWid = 200;
		buttonHeight = 50;
		originpoint_x = Screen.width / 2 - buttonWid / 2;
		originpoint_y = Screen.height / 2 - buttonHeight;

	}
	
	void OnGUI(){
		if (GUI.Button (new Rect (originpoint_x, originpoint_y, buttonWid, buttonHeight), "Roll a Ball")) {
			Debug.Log ("ok");
			SceneManager.LoadScene ("MiniGame", LoadSceneMode.Single);
		}
		if (GUI.Button (new Rect (originpoint_x, originpoint_y + buttonHeight + 20, buttonWid, buttonHeight), "Colonel Blitz")) {
			Debug.Log ("ok");
			SceneManager.LoadScene ("Colonel Blitz", LoadSceneMode.Single);
		}

		if (GUI.Button (new Rect (originpoint_x, originpoint_y + 2 * buttonHeight + 40, buttonWid, buttonHeight), "Exit")) {
			Debug.Log ("ok");
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}
	}
}



