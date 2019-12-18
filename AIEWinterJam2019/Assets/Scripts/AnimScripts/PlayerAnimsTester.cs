using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsTester : MonoBehaviour
{
    public Animator animator;
    public AudioManager audioManager;
    public AudioClip walkSound;
    public PlayerScript p;
    public float sECooldown, maxDelay = 2;
    

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

        // Audio testing
        //if(Input.GetKey(KeyCode.A) && sECooldown < Time.deltaTime)
        //{
        //    Debug.Log("Audio Que");
        //    sECooldown += Time.deltaTime + .62f;
        //}
        #endregion

        #region Shooting
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S) && sECooldown <= 0)
        {
            animator.SetBool("FireDown", true);
            sECooldown = maxDelay;
        }
        else animator.SetBool("FireDown", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && sECooldown <= 0)
        {
            animator.SetBool("FireUp", true);
            sECooldown = maxDelay;
        }
        else animator.SetBool("FireUp", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && sECooldown <= 0)
        {
            animator.SetBool("FireLeft", true);
            sECooldown = maxDelay;
        }
        else animator.SetBool("FireLeft", false);

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && sECooldown <= 0)
        {
            animator.SetBool("FireRight", true);
            sECooldown = maxDelay;
        }
        else animator.SetBool("FireRight", false);

        if (Input.GetKeyDown(KeyCode.Space) && sECooldown <= 0)
        {
            animator.SetBool("FireDown", true);
            sECooldown = maxDelay;
        }
        else animator.SetBool("FireDown", false);
        #endregion

        #region Melee
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S))
        {
            animator.SetBool("HitDown", true);
            FindObjectOfType<AudioManager>().Play("PumpkinMelee");
        }
        else animator.SetBool("HitDown", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            animator.SetBool("HitUp", true);
            FindObjectOfType<AudioManager>().Play("PumpkinMelee");
        }
        else animator.SetBool("HitUp", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.A))
        {
            animator.SetBool("HitLeft", true);
            FindObjectOfType<AudioManager>().Play("PumpkinMelee");
        }
        else animator.SetBool("HitLeft", false);

        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("HitRight", true);
            FindObjectOfType<AudioManager>().Play("PumpkinMelee");
        }
        else animator.SetBool("HitRight", false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("HitDown", true);
            FindObjectOfType<AudioManager>().Play("PumpkinMelee");
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
        if(sECooldown > 0)
        {
            sECooldown -= Time.deltaTime;
        }
    }
}
