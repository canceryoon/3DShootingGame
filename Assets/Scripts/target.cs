using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
		Variables.scores += 10;
		Variables.targets += 1;
		gameObject.SetActive (false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
