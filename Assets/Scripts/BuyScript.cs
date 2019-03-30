using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyScript : MonoBehaviour,IPointerDownHandler {
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold > 10)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().arrows += 10;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HealthAmmoEquip>().gold -= 10;
        }
    }
    
}
