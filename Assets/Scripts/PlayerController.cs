using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Material playerMaterial;
    private float startPosX;
    private float startPosY;
    private bool isBeigHeld = false;
    private Renderer playerRenderer;
    private Vector4 playerColor = new Vector4(1, 1, 1,1);

    void Start()
    {
        playerRenderer = this.gameObject.GetComponent<Renderer>();
        playerColor = new Vector3(255, 0, 0);
        playerRenderer.material.SetColor("_color", playerColor);
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


    }

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




    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Charging Station")
        {
            playerColor = new Vector4(0, 255, 0);
            playerRenderer.material.SetColor("_color", playerColor);
        }
        else
        {
            playerColor = new Vector4(157, 0, 0);
            playerRenderer.material.SetColor("_color", playerColor);

        }
    }

}
