using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BuyScript : MonoBehaviour,IPointerDownHandler {
    /* public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Playercontroller>().canShoot = false;
        print("over GameObject.");
    }*/
    /*public void OnPointerExit(PointerEventData eventData)
    {
        print("Exiting");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Playercontroller>().canShoot = true;
    }*/
    public void BuyArrows()
    {
       
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows += 10;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print(gameObject.name);
        
            switch (gameObject.name)
            {
                case "arrows":
                    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold > 9)
                    {
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows += 10;
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
                    }
                    break;
                /*case "arrowsale":
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows -= 10;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold += 10;
                    break;*/
                case "health":
                    if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold > 9)
                    {
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health += 10;
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
                    }
                    break;
            case "exit":
                Application.Quit();
                break;
            
        }
    }
    
}
