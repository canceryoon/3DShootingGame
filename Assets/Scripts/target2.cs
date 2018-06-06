using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target2 : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("asfdasf");
        ani.Play("Take 001");
    }

    Animator ani = null;

    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
