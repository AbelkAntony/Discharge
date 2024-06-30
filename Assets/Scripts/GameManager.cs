using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    private float playerRange;

    
    public void SetPlayerRange(float radius) {    playerRange = radius;     }


    public Vector3 Getplayerlocation()  {   return player.Getplayerlocation();   }
    public float GetPlayerRange()       
    {
        playerRange = player.GetPlayerRange();
        return playerRange;   
    }

}
