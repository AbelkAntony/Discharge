using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    //[SerializeField] GameObject bullet;
    private bool isGunActivate;
    private float distance;
    private void Start()
    {
        isGunActivate = false;  
    }
    private void Update()
    {
        distance = Vector3.Distance(gameManager.Getplayerlocation(), this.transform.position);
        //Debug.Log(distance);
        if (distance < gameManager.GetPlayerRange())
        {
            isGunActivate = true;
            Fire();
        }
        else { isGunActivate = false; }


    }

    public bool IsGunActivated(){   return isGunActivate;   }


    private void Fire()
    {
        if (isGunActivate)
        {
            Debug.Log("gun activated");
        }
    }
}
