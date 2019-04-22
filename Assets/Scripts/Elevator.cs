using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public bool goingup, elevater,underneath;
    public float originalHight, maxheight, minhieght,speed;
    // Use this for initialization
    void Awake () {
        //elevater = false;
        goingup = true;
        maxheight = Random.Range(1, 10);
        minhieght = Random.Range(1, 10)*-1;
        speed = Random.Range(1f, 10f)/100f;
        originalHight = gameObject.transform.position.y;
        
    }
    private void Start()
    {
        if (elevater)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 3, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            gameObject.AddComponent<BoxCollider2D>();

        }

    }

    // Update is called once per frame
    void Update () {
        
        if (elevater)
        {
            
            if (goingup == true)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed);
                if (gameObject.transform.position.y > originalHight + maxheight)
                {
                    goingup = false;
                }
            }
            else
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - speed);
                if (gameObject.transform.position.y < originalHight + minhieght)
                {
                    goingup = true;
                }
            }

        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (elevater)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (elevater)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }




}
