using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color charging;
    [SerializeField] Color discharging;
    [SerializeField] Color ideal;
    private float startPosX;
    private float startPosY;
    private bool isBeigHeld = false;
    private Renderer playerRenderer;
    private Vector4 playerColor = new Vector4(1, 1, 1,1);
    private bool isCharging;
    private bool isdischarging;
    private float charge = 100f;
    private int chargingMultiplier = 1;
    private int dischargingMultiplier = 1;
    private float playerRange;
    void Start()
    {
        playerRenderer = this.gameObject.GetComponent<Renderer>();
        playerColor = new Vector3(255, 0, 0);
        playerRenderer.material.SetColor("_color", playerColor);
        playerRange = 1f;
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
            Debug.Log(charge);
        }
        if(!isCharging && gameManager.IsGunActivated() && charge>=0)
        {
            charge -= Time.deltaTime * dischargingMultiplier;
            sr.color = discharging;
            Debug.Log(charge);
        }

    }

    public void IsDischarging(bool state) { isdischarging = state; }

    public Vector3 Getplayerlocation() { return this.transform.position; }

    public float GetPlayerRange() { return playerRange; }

    public float GetPlayerCharge() { return charge; }

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
            sr.color = charging;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Charging Station")
        {
            isCharging = false;
            sr.color = ideal;
        }
    }


}
