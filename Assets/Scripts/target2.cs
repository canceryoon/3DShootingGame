using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target2 : MonoBehaviour {

    Animator ani = null;
    bool hitting = false;

    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (!hitting)
        {
            hitting = true;
            Variables.scores += 10;
            StartCoroutine(endTaret());
        }
    }

    IEnumerator endTaret()
    {
        ani.Play("hit");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Variables.targets += 1;
    }
}
