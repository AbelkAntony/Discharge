using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Material playerMaterial;
    private float startPosX;
    private float startPosY;
    private bool isBeigHeld = false;
    private Renderer playerRenderer;
    private Vector4 playerColor = new Vector4(1, 1, 1,1);
    private bool isCharging;
    private bool isdischarging;
    private float charge;
    private int chargingMultiplier = 1;
    private int dischargingMultiplier = 1;
    private float playerRange;
    void Start()
    {
        playerRenderer = this.gameObject.GetComponent<Renderer>();
        playerColor = new Vector3(255, 0, 0);
        playerRenderer.material.SetColor("_color", playerColor);
        playerRange = .2f;
    }

    void Update()
    {
        if(isBeigHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }


        if(isCharging && charge <=100)
        {
            charge += Time.deltaTime* chargingMultiplier;
        }
        else if(isdischarging && charge>=0)
        {
            charge -= Time.deltaTime * dischargingMultiplier;
        }


    }

    public void IsDischarging(bool state) { isdischarging = state; }

    public Vector3 Getplayerlocation() { return this.transform.position; }

    public float GetPlayerRange() { return GetPlayerRange(); }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeigHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeigHeld = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charging Station")
        {
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charging Station")
        {
            isCharging = false;
        }
    }


}
