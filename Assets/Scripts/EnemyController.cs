using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 moveTo;
    private GameObject player;
    private float speed = 1;
    private Vector3 spawnLocation;
    private void Start()
    {
        spawnLocation = this.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        moveTo = player.transform.position;
    }

    private void Update()
    {
        speed = 1 * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, moveTo,speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Reset();
        }
    }

    private void Reset()
    {
        this.gameObject.transform.position = spawnLocation;
        player = GameObject.FindGameObjectWithTag("Player");
        moveTo = player.transform.position;
    }
}
