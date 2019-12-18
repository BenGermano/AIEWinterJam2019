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
            Debug.Log("UH OH");
            isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("UH OH");
            isAttacking = false;
        }
    }
}
