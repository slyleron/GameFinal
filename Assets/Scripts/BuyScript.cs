using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyScript : MonoBehaviour,IPointerDownHandler {
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold > 10)
        {
            switch (gameObject.name)
            {
                case "arrows":
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows += 10;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
                    break;
                case "arrowsale":
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows -= 10;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold += 10;
                    break;
                case "health":
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health += 10;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
                    break;
                case "healthtogold":
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().health -= 10;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold += 10;
                    break;
            }
        }
    }
    
}
