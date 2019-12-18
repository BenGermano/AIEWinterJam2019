using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenEnemyAttackAI : MonoBehaviour
{
    public bool isAttacking;

    public CircleCollider2D radiusHitbox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            FindObjectOfType<AudioManager>().Play("EnemyMelee");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = false;
        }
    }
}
