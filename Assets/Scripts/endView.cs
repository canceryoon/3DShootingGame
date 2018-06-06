using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endView : MonoBehaviour {

	public Text endMsg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		endMsg.text = Variables.playerName + " score: " + Variables.scores;
	}
}
