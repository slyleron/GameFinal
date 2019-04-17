using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFlight : MonoBehaviour {
    public GameObject arrow, player,death;
    private bool alive=true;
    public float arrowdamage=10;
    
	
	
	// Update is called once per frame
	void Update () {
        //Vector3 dir = rigidbody.velocity;
       
        player = GameObject.FindGameObjectWithTag("Player");
        if (alive)
        {
            Vector3 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(),false);
            float rotationholder = gameObject.transform.rotation.z;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            //Physics2D.IgnoreCollision(arrow.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(),false);
            //gameObject.transform.rotation = Quaternion.Euler( new Vector3(gameObject.transform.rotation.x,gameObject.transform.rotation.y, rotationholder));
            alive = false;
        }
        if(collision.collider.CompareTag("BadGuys"))
            Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
        if (collision.collider.CompareTag("Player")&&!alive)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows++;
            Destroy(gameObject.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
  //      print(collision.tag);
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows++;
            Destroy(gameObject.gameObject);
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
//        print(collision.tag);
        if (!alive)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            //Physics2D.IgnoreCollision(arrow.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(),false);
            //gameObject.transform.rotation = Quaternion.Euler( new Vector3(gameObject.transform.rotation.x,gameObject.transform.rotation.y, rotationholder));
           // alive = true;

        }
    }

}
