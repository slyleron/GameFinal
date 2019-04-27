using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlowmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x / 5, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y / 5, 0);

    }
}
