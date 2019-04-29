using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndBuy : MonoBehaviour {
    private bool pause;
    private float timesaver;
    public GameObject whatToShow;
	// Use this for initialization
	void Start () {
        timesaver = Time.timeScale;
        Time.timeScale = 0;
        //whatToShow.SetActive(true);
        whatToShow.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y, 0);
        pause = !pause;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Time.timeScale = 0;
                //whatToShow.SetActive(true);
                whatToShow.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y, 0);
                pause = !pause;
            }
            else
            {
                Time.timeScale = timesaver;
                whatToShow.transform.position = new Vector3(0, 500, 0);
                //whatToShow.SetActive(false);
                pause = true;                                               
            }
        }
	}
}
