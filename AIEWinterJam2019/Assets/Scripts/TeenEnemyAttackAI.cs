using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenEnemyAttackAI : MonoBehaviour
{
    public BoxCollider2D attackHitbox;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("oof");
        }
    }
}
