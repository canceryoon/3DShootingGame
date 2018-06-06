using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Variables{
	public static string playerName = "";
	public static int scores = 0;
	public static int targets = 0;
}

public class startView : MonoBehaviour {

	public Button startBtn;
	public InputField playerName;

	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (startGame);
	}

	void startGame()
	{
		if (playerName.text == "")
			Debug.Log ("Plz... Input Player Name");
		else {
			Debug.Log ("START GAME");
			Variables.playerName = playerName.text.ToString ();
			SceneManager.LoadScene ("main");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
