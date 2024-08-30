using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 moveTo;
    private GameObject[] player;
    private float speed = 1;
    private Vector3 spawnLocation;
    private float minSize = 0.5f;
    private float maxSize = 1.5f;
    private int life = 5;
    private float size = 1f;
    private GameObject attackingPlayer;
    private int numberOfPlayers;
    private int score;
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        numberOfPlayers = player.Length;
        attackingPlayer = player[Random.Range(0, numberOfPlayers)];
        spawnLocation = this.gameObject.transform.position;
        moveTo = attackingPlayer.transform.position;
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
        else if(collision.gameObject.tag == "Bullet")
        {
            //TakeDamage(GetComponent<GameManager>().GetBulletDamage());
            TakeDamage(FindAnyObjectByType<GameManager>().GetBulletDamage());
        }
    }

    private void Reset()
    {
        size = Random.Range(minSize, maxSize);
        this.transform.localScale = Vector3.one * this.size;
        this.gameObject.transform.position = spawnLocation;
        attackingPlayer = player[Random.Range(0, numberOfPlayers)];
        life = Random.Range(1, 6);
        score = Random.Range(1, 10);
        moveTo = attackingPlayer.transform.position;
    }

    private void GetDirection()
    {

    }

    private void TakeDamage(int damage)
    {
        if(life > 0)
        {
            this.life = life - damage; 
        }
        else if (life< =0)
        {
            Reset();
            GameManager.AddScore(score);
        }

    }
}
