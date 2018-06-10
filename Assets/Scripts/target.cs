using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
//
    Animator ani = null;

    // Use this for initialization
    void Start ()
    {
  //      ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
		Variables.scores += 10;
		Variables.targets += 1;
        gameObject.SetActive(false);
        //      StartCoroutine(endTaret());
    }

 //   IEnumerator endTaret()
  //  {
  //      ani.Play("hit");
   //     yield return new WaitForSeconds(3);
  //      gameObject.SetActive(false);
 //   }
}
