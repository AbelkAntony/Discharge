using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletSpawnLocation;
    [SerializeField] GameObject bulletPrefab;
    //[SerializeField] GameObject bullet;
    private bool isGunActivate;
    private Vector3 playerlocation;
    private float distance;
    private void Start()
    {
        isGunActivate = false;
        playerlocation = gameManager.Getplayerlocation();
    }
    private void Update()
    {
        if(playerlocation != gameManager.Getplayerlocation())
        {
            playerlocation = gameManager.Getplayerlocation();
            distance = Vector3.Distance(gameManager.Getplayerlocation(), this.transform.position);
            if (distance <= gameManager.GetPlayerRange())
            {
                isGunActivate = true;
                Fire();
            }
            else { isGunActivate = false; }
            
        }
        


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
