using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y,gameObject.transform.position.z); 
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health = 0;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
