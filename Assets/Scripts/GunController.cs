using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bulletSpawnLocation;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float defaultSpeed = 10;
    //[SerializeField] GameObject bullet;
    private bool isGunActivate;
    private Vector3 playerlocation;
    private float distance;
    private GameObject enemy;
    
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

        RotateGun();

    }

    public bool IsGunActivated(){   return isGunActivate;   }


    private void Fire()
    {
        if (isGunActivate)
        {
            Debug.Log("gun activated");
        }
    }

    private void RotateGun()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 targetDirection =    enemy.transform.position - transform.position ;
        Quaternion rotate = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetDirection), defaultSpeed*Time.deltaTime);
        rotate.x = 0;
        rotate.y = 0;
        //rotate.z = rotate.z - 45;
        this.transform.rotation = rotate;
        
    }
}
