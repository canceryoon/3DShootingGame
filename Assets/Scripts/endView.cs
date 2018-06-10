using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endView : MonoBehaviour {

	public Text endMsg;
    public Text titile;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        titile.text =(Variables.success)? "Game Clear!" : "Game Over...";
        
		endMsg.text = Variables.playerName + " score: " + Variables.scores;
	}
}
