using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowShooter : MonoBehaviour {
    public GameObject bullet, mouse,bow,player;
    public GameObject healthbar,otherhealhtbar;
    private float power,healthbarMaxSize,originalhealthbar;
    public float poweruprate;
    // Use this for initialization
    void Start () {
        healthbarMaxSize = .3828125f;
        power = 0;
        poweruprate = 0.2f;
        originalhealthbar = healthbar.GetComponent<RectTransform>().offsetMax.x;
    }
	
	// Update is called once per frame
	void Update () {
        //healthbar.transform.localScale = ;
        
        
        if (Input.GetMouseButton(0))
        {
            
            
            if (healthbar.GetComponent<RectTransform>().offsetMax.x < otherhealhtbar.GetComponent<RectTransform>().offsetMax.x) { 
                power += poweruprate;
                healthbar.GetComponent<RectTransform>().offsetMax = new Vector3(healthbar.GetComponent<RectTransform>().offsetMax.x + power, healthbar.GetComponent<RectTransform>().offsetMax.y);

            }
        }
        //releaseMouseAndFire
        if (Input.GetMouseButtonUp(0))
        {
            //gameObject.transform.position = bow.transform.position;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            GameObject flybulletfly = Instantiate(bullet, gameObject.transform.parent);// Quaternion.Euler(new Vector3(0, 0, 0)));
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), flybulletfly.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(flybulletfly.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            flybulletfly.transform.LookAt(mouse.transform.position);
            flybulletfly.transform.position = new Vector3(bow.transform.position.x,bow.transform.position.y,bow.transform.position.z);
            flybulletfly.GetComponent<Rigidbody2D>().velocity = flybulletfly.transform.forward * power;
            //flybulletfly.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            healthbar.GetComponent<RectTransform>().offsetMax = new Vector3(originalhealthbar, healthbar.GetComponent<RectTransform>().offsetMax.y);

            power = 0;
            
        }
        
    }
}
