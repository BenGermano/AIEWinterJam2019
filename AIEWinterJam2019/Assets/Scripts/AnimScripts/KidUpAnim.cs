using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidUpAnim : MonoBehaviour
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
            animator.SetBool("Up", true);
            animator.SetBool("CarryDown", false);
            animator.SetBool("Carving", false);
        }
        if (enemy.hasPumpkin == true)
        {
            animator.SetBool("CarryDown", true);
            animator.SetBool("Up", false);
            animator.SetBool("Carving", false);
        }
        if (enemy.isCarving == true)
        {
            animator.SetBool("Carving", true);
            animator.SetBool("CarryDown", false);
            animator.SetBool("Up", false);
        }
    }
}
