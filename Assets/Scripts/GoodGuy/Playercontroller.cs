using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour {
    public float jumphight, moveSpeed, moveSlow,duckDistance;
    private bool jump;
    public GameObject bullet, mouse, bow, player;
    public GameObject healthbar, otherhealhtbar;
    private float power, healthbarMaxSize, originalhealthbar;
    public float poweruprate;
    
    // Use this for initialization
    void Start () {

        PlayerPrefs.SetFloat("lastCheckpointX", 0);
        PlayerPrefs.SetFloat("lastCheckpointY", 2);
        PlayerPrefs.SetFloat("lastCheckpointZ", 122);
        healthbarMaxSize = .3828125f;
        power = 0f;
        poweruprate = 0.3f;
        originalhealthbar = healthbar.GetComponent<RectTransform>().offsetMax.x;
        jumphight = 5;
        moveSpeed = 2f;
        moveSlow = moveSpeed / 3;
        duckDistance = -.1f;
        jump = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)&&jump|| Input.GetKey(KeyCode.Space) && jump)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y+jumphight);
            jump = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (mouse.transform.localPosition.x > gameObject.transform.position.x)
        {
             
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        //arrowpower
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows > 0)
        {
            if (Input.GetMouseButton(0)&& GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health > 0)
            {


                if (healthbar.GetComponent<RectTransform>().offsetMax.x < otherhealhtbar.GetComponent<RectTransform>().offsetMax.x)
                {
                    power += poweruprate;
                    healthbar.GetComponent<RectTransform>().offsetMax = new Vector3(healthbar.GetComponent<RectTransform>().offsetMax.x + power, healthbar.GetComponent<RectTransform>().offsetMax.y);

                }
            }

            //releaseMouseAndFire
            if (Input.GetMouseButtonUp(0)&& GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health>0)
            {

                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
                GameObject flybulletfly = Instantiate(bullet, gameObject.transform.parent);
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), flybulletfly.GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(flybulletfly.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
                flybulletfly.transform.LookAt(mouse.transform.localPosition);
                flybulletfly.transform.position = new Vector3(bow.transform.position.x, bow.transform.position.y, bow.transform.position.z);
                //print(bow.transform.position.x);
                if (power < .3f) power = 5;
                flybulletfly.GetComponent<Rigidbody2D>().velocity = flybulletfly.transform.forward * power*10;
                healthbar.GetComponent<RectTransform>().offsetMax = new Vector3(originalhealthbar, healthbar.GetComponent<RectTransform>().offsetMax.y);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows--;
                power = 0;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Ground")
        {
            jump = true;
        }
        if (collision.collider.tag == "Gold")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold += Random.Range(5, 10);

            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold += Random.Range(GameObject.Find("GroundPrefabHolder").GetComponent<GroundMaker>().level, 50+ GameObject.Find("GroundPrefabHolder").GetComponent<GroundMaker>().level);
            GameObject.Find("GroundPrefabHolder").GetComponent<GroundMaker>().GroundMakerScript();
            GameObject.Find("GroundPrefabHolder").GetComponent<GroundMaker>().level++;
            PlayerPrefs.SetFloat("lastCheckpointX", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("lastCheckpointY", gameObject.transform.position.y);
            PlayerPrefs.SetFloat("lastCheckpointZ", gameObject.transform.position.z);
            GameObject.Find("LevelText").GetComponent < Text >().text= GameObject.Find("GroundPrefabHolder").GetComponent<GroundMaker>().level.ToString();
            Destroy(collision.gameObject);
        }
    }
}
