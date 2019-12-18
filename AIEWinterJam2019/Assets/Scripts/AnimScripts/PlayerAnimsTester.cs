using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsTester : MonoBehaviour
{
    public Animator animator;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        #region WASD
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            //audioManager.Play("PumpkinWalking");
        }
        else animator.SetBool("Right", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
        }
        else animator.SetBool("Left", false);

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Right", false);
            animator.SetBool("Idle", false);
        }
        else animator.SetBool("Down", false);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
        }
        else animator.SetBool("Up", false);
        #endregion

        #region Shooting
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("FireDown", true);
        }
        else animator.SetBool("FireDown", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("FireUp", true);
        }
        else animator.SetBool("FireUp", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("FireLeft", true);
        }
        else animator.SetBool("FireLeft", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FireRight", true);
        }
        else animator.SetBool("FireRight", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("FireDown", true);
        }
        else animator.SetBool("FireDown", false);
        #endregion

        #region Melee
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("HitDown", true);
        }
        else animator.SetBool("HitDown", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("HitUp", true);
        }
        else animator.SetBool("HitUp", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("HitLeft", true);
        }
        else animator.SetBool("HitLeft", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("HitRight", true);
        }
        else animator.SetBool("HitRight", false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("HitDown", true);
        }
        else animator.SetBool("HitDown", false);
        #endregion

        if(!Input.anyKey)
        {
            animator.SetBool("Up", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Down", false);
            animator.SetBool("HitDown", false);
            animator.SetBool("HitUp", false);
            animator.SetBool("HitLeft", false);
            animator.SetBool("HitRight", false);
            animator.SetBool("FireDown", false);
            animator.SetBool("FireUp", false);
            animator.SetBool("FireLeft", false);
            animator.SetBool("FireRight", false);
            animator.SetBool("Idle", true);
        }
    }
}
