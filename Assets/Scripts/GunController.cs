using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject bullet;
    private bool isGunActivate;
    private float distance;
    private Vector3 playerLocation;
    private void Start()
    {
        isGunActivate = false;
        
    }
    private void Update()
    {
        if (Vector3.Distance(gameManager.Getplayerlocation(),this.transform.position)<gameManager.GetPlayerRange())
        {

        }
       
    }
}
