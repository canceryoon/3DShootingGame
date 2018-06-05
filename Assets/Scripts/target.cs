using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
