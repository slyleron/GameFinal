using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMaker : MonoBehaviour {
    public GameObject prefabGround,parent,checkpoint, badguySprite;
    public int totalGroundDesired,count,level;
    private float counter,badGuyCounter,lastup, lastright,randomUP, randomRight;
   
    // Use this for initialization
    void Main () {
        counter = 1;
        GroundMakerScript();
        level = 1;
        
    }
    
    public void GroundMakerScript()
    {
        
        count = 1;
        totalGroundDesired = 50;
        do
        {
            randomUP = Random.Range(-.2f, .2f);

            randomRight = .75f;
            GameObject tempGameObject = Instantiate(prefabGround, parent.transform);
            
            
            tempGameObject.transform.position = new Vector3(randomRight + lastright, randomUP + lastup);
            counter = tempGameObject.transform.position.x;
            lastup = tempGameObject.transform.position.y;
            lastright = tempGameObject.transform.position.x;
            
            GameObject badguy = Instantiate(badguySprite, new Vector2(tempGameObject.transform.position.x, tempGameObject.transform.position.y+2),tempGameObject.transform.rotation);
            if (Random.Range(0, 50) > 1+level)
            {
                Destroy(badguy.gameObject);
            }
            if (Random.Range(0, 50) > 1 + level)
            {
                tempGameObject.GetComponent<Elevator>().elevater = false;
            }else
            {
                tempGameObject.GetComponent<Elevator>().elevater = true;
                lastup = tempGameObject.GetComponent<Elevator>().maxheight+ tempGameObject.GetComponent<Elevator>().originalHight-1f;


            }
            count++;

        }
        while (totalGroundDesired > count);
        Instantiate(checkpoint, new Vector2(counter, lastup + 1), gameObject.transform.rotation);
        
        
    }
    
}
