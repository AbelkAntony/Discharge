using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStationController : MonoBehaviour
{ 
    private Renderer chargingStationRenderer;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color charging;
    [SerializeField] Color discharging;
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
        }
        else if(isCharging == false && charge < 100)
        {
            charge += Time.deltaTime;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            sr.color = discharging; 
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.color = charging;
        isCharging = false;
    }
}
