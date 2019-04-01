using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAmmoEquip : MonoBehaviour {
    public int health, arrows, mana, gold;
    public GameObject healthbar, healthbarMax;
    public ParticleSystem spawnParticles, deathparticles;
    public Text goldText,arrowText;
    public float healthMath;
    private bool whichParticle;
	// Use this for initialization
	void Start () {
        
        health = 100;
        arrows = 10;
        mana = 100;
        

    }
	
	// Update is called once per frame
	void Update () {
        
        healthMath = (healthbarMax.GetComponent<RectTransform>().offsetMax.x-healthbarMax.GetComponent<RectTransform>().offsetMin.x) / 100;
        healthbar.GetComponent<RectTransform>().offsetMax = new Vector3(healthMath*health- healthbarMax.GetComponent<RectTransform>().offsetMax.x, healthbar.GetComponent<RectTransform>().offsetMax.y);
        goldText.text = gold.ToString();
        gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y,-50);
        arrowText.text = arrows.ToString();
        if (health < 1)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, new Vector3(PlayerPrefs.GetFloat("lastCheckpointX"), PlayerPrefs.GetFloat("lastCheckpointY")+1, PlayerPrefs.GetFloat("lastCheckpointZ")), .01f);
            GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            if (whichParticle)
            {

            }
            if (GameObject.FindGameObjectWithTag("Player").transform.position.x < PlayerPrefs.GetFloat("lastCheckpointX") + 1f&& GameObject.FindGameObjectWithTag("Player").transform.position.x > PlayerPrefs.GetFloat("lastCheckpointX")-1&& GameObject.FindGameObjectWithTag("Player").transform.position.y > PlayerPrefs.GetFloat("lastCheckpointY"))
            {
                health = 100;
                arrows = 10;
                if (gold > 50)
                {
                    gold -=50;
                }
                else gold = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().isTrigger = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().isKinematic = false;
                ParticleSystem particles=Instantiate(spawnParticles);
                particles.Play(true);
                whichParticle = true;
            }
        }

    }
}
