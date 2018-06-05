using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
			SceneManager.LoadScene ("main");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
