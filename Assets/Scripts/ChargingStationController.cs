using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStationController : MonoBehaviour
{ 
    private Renderer chargingStationRenderer;
    private Color chargingStationColor;
    private float charge;
    private bool isCharging = false;
    void Start()
    {
        chargingStationRenderer = GetComponent<Renderer>();
        charge = 100;
    }

    private void Update()
    {
        if(isCharging && charge > 0)
        {
            charge -= Time.deltaTime*2;
            //Debug.Log(charge);
        }
        else if(isCharging == false && charge < 100)
        {
            charge += Time.deltaTime;
            //Debug.Log(charge);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("collision enter");
            chargingStationColor = new Color(255, 0, 0);
            chargingStationRenderer.material.color = Color.red;
            //this.gameObject.GetComponent<Renderer>().material.SetColor("_color", chargingStationColor);
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("collision exit");
        chargingStationColor = new Color(0, 255, 0);
        chargingStationRenderer.material.SetColor("_color", chargingStationColor);
        isCharging = false;
    }
}
