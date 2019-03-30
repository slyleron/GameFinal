using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour {
    public float life, moveSpeed, jumpHeight, fastSpeed;
    private bool moveRight;
    public int damageOutput,level = 1;
    public GameObject gold;
    public Transform GroundCheck1; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here
    public float groundchecksize;
    // Use this for initialization
    void Start () {
        life = Random.Range(20, 30);
        moveSpeed = (Random.Range(.5f, 4f));
        fastSpeed = moveSpeed * 1.5f;
        moveRight = true;
        groundchecksize = .14f;



    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
        {
            Instantiate(gold, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject.gameObject);
        }
        if (Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) { 
            if (gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x < 5 && gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x > 1)
            {
                if (gameObject.transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }

        }
    }
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageOutput = Random.Range(1, 5) * level;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health-=damageOutput;
        }
        
    }
}
