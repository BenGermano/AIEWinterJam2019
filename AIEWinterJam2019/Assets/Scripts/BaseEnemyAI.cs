﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    // Player references.
    public PlayerScript player;

    // Timer references.
    public GameTimer gameTimeScript;

    // Waypoint game objects.
    public GameObject table;
    public GameObject pickup;
    public GameObject spawn;
    
    // Varables that control behaviour.
    public float speed;
    public  float timer = 0;
    public bool hasPumpkin = false;
    public bool isCarving = false;
    public bool dead = false;

    private float speedModifer = 1;
    public float spawnDelay = 0;

    // Components of the object.
    public Transform target;
    private SpriteRenderer spr;
    private BoxCollider2D col;
    private Rigidbody2D RB;

    void Start()
    {
        // Getting components of the object.
        spr = gameObject.GetComponent<SpriteRenderer>();
        col = gameObject.GetComponent<BoxCollider2D>();
        RB = gameObject.GetComponent<Rigidbody2D>();

        target = table.transform;
        StartCoroutine(Countdown(TimeToCountdownFrom() + spawnDelay));
    }

    void Update()
    {
        // The check for carving is here in update, because the countdown
        // runs parallel to any updating things.
        if (isCarving)
        {
            // Sucsessfully carved. Take a life and activate cooldown.
            if (timer <= 0)
            {
                isCarving = false;
                hasPumpkin = false;
                Debug.Log("Foolish pumpkin,,,, you are TOO LATE.");
                player.health -= 1;
                StartCoroutine(Countdown(TimeToCountdownFrom()));
                FindObjectOfType<AudioManager>().Play("Carving");
            }
        }

        // Timer is used by carving, cooldown, and death, and prevents the Enemy from moving.
        if (timer <= 0)
        {
            speedModifer = 1 + (gameTimeScript.ellapsedTime / 30);
            transform.position = Vector3.MoveTowards(transform.position, target.position, (speed * speedModifer) * Time.deltaTime);
        }

        // TODO: Make the enemy able to be hit by the player's attack.
        // When that happens, "dead" is flicked to true.
        if (dead)
        {
            Die();
        }
    }

    // In case of the enemy getting stuck inside and not triggering OnEnter.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (ReferenceEquals(other.gameObject, spawn))
        {
            //Debug.Log("Am Respawning");
            speedModifer = 1;
            spr.enabled = true;
            dead = false;
            target = table.transform;
            StartCoroutine(Countdown(TimeToCountdownFrom()));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy gets to the table.
        if (ReferenceEquals(collision.gameObject, table))
        {
            //Debug.Log("Am Table");
            // If the enemy has a pumpkin, begin carving upon collision.
            // Carving is always 6 seconds.
            if (hasPumpkin)
            {
                StartCoroutine(Countdown(4));
                isCarving = true;
                FindObjectOfType<AudioManager>().Play("Carving");
            }
            target = pickup.transform;
        }

        // Enemy gets to the pumpkin pick-up point (PPP).
        if (ReferenceEquals(collision.gameObject, pickup))
        {
            //Debug.Log("Am Pickup");
            hasPumpkin = true;
            target = table.transform;
        }

        // Enemy has died and has gone back to the spawnpoint.
        if (ReferenceEquals(collision.gameObject, spawn))
        {
            //Debug.Log("Am Respawning");
            speedModifer = 1;
            spr.enabled = true;
            dead = false;
            target = table.transform;
            StartCoroutine(Countdown(TimeToCountdownFrom()));
        }

        // Enemy gets hit by an attack.
        if(collision.gameObject.tag == "pAttack")
        {
            dead = true;
            FindObjectOfType<AudioManager>().Play("EnemyDamaged");
        }
    }

    // The countdown enumerator that the enemy uses upon carving, cooldown, and death.
    private IEnumerator Countdown(float timerValue)
    {
        timer = timerValue;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
    }

    private float TimeToCountdownFrom()
    {
        // Generate a value from 0-2 then add 2 more to it.
        // You will have always have a 2 second minimum cooldown.
        float temp = Random.Range(0, 2);
        temp += 1;
        return temp;
    }

    // Sends the enemy back to the spawnpoint.
    private void Die()
    {
        
        isCarving = false;
        hasPumpkin = false;
        spr.enabled = false;
        target = spawn.transform;
        speedModifer = 100;
        timer = 0;
    }
}
