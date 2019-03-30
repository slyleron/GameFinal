using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour {

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
                    break;
                case "Arm":
                    gameObject.GetComponentInParent<BadGuy>().life -= collision.collider.GetComponent<ArrowFlight>().arrowdamage / 10;
                    gameObject.GetComponentInParent<BadGuy>().damageOutput = gameObject.GetComponentInParent<BadGuy>().damageOutput / 2;
                    break;
                case "Chest":
                    gameObject.GetComponentInParent<BadGuy>().life -= collision.collider.GetComponent<ArrowFlight>().arrowdamage;
                    break;
                case "Head":
                    gameObject.GetComponentInParent<BadGuy>().life -= collision.collider.GetComponent<ArrowFlight>().arrowdamage * 1.5f;
                    break;

            }
        }
    }
}
