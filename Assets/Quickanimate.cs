using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quickanimate : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            var allAnims = FindObjectsOfType<Animation>();
            foreach (var anim in allAnims)
            {
                anim.Stop();
            }


        }
        
	}
}
