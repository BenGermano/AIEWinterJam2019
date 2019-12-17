using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDownAnim : MonoBehaviour
{
    public BaseEnemyAI enemy;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.hasPumpkin == false)
        {
            animator.SetBool("Down", true);
            animator.SetBool("CarryUp", false);
            animator.SetBool("Carving", false);
        }
        if (enemy.hasPumpkin == true)
        {
            animator.SetBool("CarryUp", true);
            animator.SetBool("Down", false);
            animator.SetBool("Carving", false);
        }
        if (enemy.isCarving == true)
        {
            animator.SetBool("Carving", true);
            animator.SetBool("CarryUp", false);
            animator.SetBool("Down", false);
        }
    }
}
