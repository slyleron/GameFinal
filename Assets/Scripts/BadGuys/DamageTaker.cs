using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour {
    public GameObject damage,particle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string nameOfObject = gameObject.name.ToString();
        
        if (collision.collider.tag == "Arrow")
        {
            switch(nameOfObject)
            {
                case "Leg":
                    gameObject.GetComponentInParent<BadGuy>().life-= collision.collider.GetComponent<ArrowFlight>().arrowdamage/5;
                    gameObject.GetComponentInParent<BadGuy>().moveSpeed = gameObject.GetComponentInParent<BadGuy>().moveSpeed / 2;
                    //Instantiate(damage, gameObject.transform.position, gameObject.transform.rotation);
                    
                    break;
                case "Arm":

                    //Instantiate(damage, gameObject.transform.position, gameObject.transform.rotation);
                    
                    break;
                case "Chest":
                    gameObject.GetComponentInParent<BadGuy>().life -= collision.collider.GetComponent<ArrowFlight>().arrowdamage;
                    //Instantiate(damage, gameObject.transform.position, gameObject.transform.rotation);
                    
                    break;
                case "Head":
                    gameObject.GetComponentInParent<BadGuy>().life -= collision.collider.GetComponent<ArrowFlight>().arrowdamage * 1.5f;
                    //Instantiate(damage, gameObject.transform.position, gameObject.transform.rotation);
                    
                    break;

            }
        }
    }
}
