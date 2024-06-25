using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStationController : MonoBehaviour
{
    [SerializeField] Material chargingStationMaterial;
    private Renderer chargingStationRenderer;
    private Color chargingStationColor;
    void Start()
    {
        chargingStationRenderer = this.gameObject.GetComponent<Renderer>();
    }



  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision enter");
        if (collision.gameObject.name == "Player")
        {
            chargingStationColor = new Color(255, 0, 0);
            //chargingStationRenderer.material.SetColor("_color", chargingStationColor);
            this.gameObject.GetComponent<Renderer>().material.SetColor("_color", chargingStationColor);
        }
        else
        {
            chargingStationColor = new Color(0, 255, 0);
            chargingStationRenderer.material.SetColor("_color", chargingStationColor);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("collision exit");
    }
}
