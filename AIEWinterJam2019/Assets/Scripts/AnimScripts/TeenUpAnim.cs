using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenUpAnim : MonoBehaviour
{
    public BaseEnemyAI enemy;
    public Animator animator;
    public TeenEnemyAttackAI teen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.hasPumpkin == false)
        {
            animator.SetBool("Up", true);
            animator.SetBool("CarryDown", false);
            animator.SetBool("Carving", false);
            animator.SetBool("Attack", false);
        }
        if(enemy.hasPumpkin == true)
        {
            animator.SetBool("CarryDown", true);
            animator.SetBool("Up", false);
            animator.SetBool("Carving", false);
            animator.SetBool("Attack", false);
        }
        if(enemy.isCarving == true)
        {
            animator.SetBool("Carving", true);
            animator.SetBool("CarryDown", false);
            animator.SetBool("Up", false);
            animator.SetBool("Attack", false);
        }
        if (teen.isAttacking == true)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Carving", false);
            animator.SetBool("CarryDown", false);
            animator.SetBool("Up", false);
        }
        else animator.SetBool("Attack", false);
    }
}
