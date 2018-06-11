using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class Variables{
	public static string playerName = "";
	public static int scores = 10;
	public static int targets = 0;
    public static int stage = 1;
    public static bool success = false;
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
        {
			#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Warnings: Who are you?", "Please enter your name", "Ok");
			#endif
            playerName.ActivateInputField();
            //playerName.Select();
        }
        else
        {
            Debug.Log("START GAME");
            Variables.playerName = playerName.text.ToString();
            SceneManager.LoadScene("main");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Return))
        {
            startGame();
        }
		
	}
}
