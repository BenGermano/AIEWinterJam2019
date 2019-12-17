using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenEnemyAttackAI : MonoBehaviour
{
    // I realize after completing this that since damage is taken on 
    // the player level, and the hitbox is toggled by the animation 
    // itself- this script literally doesn't need to be here.
    // having a Debug.Log is nice though. Hello if you see this.

    public BoxCollider2D attackHitbox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has been hit!!");
        }
    }
}
