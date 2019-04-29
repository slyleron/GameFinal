using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour {
    public float life, moveSpeed, jumpHeight, fastSpeed;
    private bool moveRight;
    public int damageOutput,level = 1;
    public GameObject gold, death;
    public Transform GroundCheck1,jumpCheck; // Put the prefab of the ground here
    public LayerMask groundLayer,badGuy; // Insert the layer here
    public float groundchecksize;
    // Use this for initialization
    void Start () {
        life = Random.Range(20, 30);
        moveSpeed = (Random.Range(2f, 3f));
        fastSpeed = moveSpeed * 1.5f;
        moveRight = false;
        groundchecksize = .36f;
        badGuy = gameObject.layer;
        



    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
        {
            Instantiate(gold, gameObject.transform.position, gameObject.transform.rotation);
            //Instantiate(death, gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject.gameObject);
        }
        if (Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) { 
            if (gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x < 10 && gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x < 1)
            {
                if (gameObject.transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed*-1, gameObject.GetComponent<Rigidbody2D>().velocity.y+.01f);
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                else//if (gameObject.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y+.01f);
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else if (moveRight)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * -1, gameObject.GetComponent<Rigidbody2D>().velocity.y + .01f);
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                if (!Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) moveRight = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y + .01f);
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                if (!Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) moveRight = true;
            }

        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (moveRight)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * -1, gameObject.GetComponent<Rigidbody2D>().velocity.y + .01f);
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                if (!Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) moveRight = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y + .01f);
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                if (!Physics2D.OverlapCircle(GroundCheck1.position, groundchecksize, groundLayer)) moveRight = true;
            }
        }
        if (Physics2D.OverlapCircle(jumpCheck.position, groundchecksize, groundLayer))
        {
            if (moveRight) moveRight = false;
            else moveRight = true;

        }
        
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageOutput = Random.Range(1, 5) * level;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health-=damageOutput;
        }
        else if (collision.CompareTag("BadGuys"))
        {
            moveRight = !moveRight;
        }
    }

}
