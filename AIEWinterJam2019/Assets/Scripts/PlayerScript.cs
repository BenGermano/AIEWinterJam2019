using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 0;
    public int health = 100;
    public int eDamage = 10;
    public int pDamage = 10;
    public Rigidbody2D rb;
    //public GameObject bullet = new GameObject();
    public GameObject nHB, sHB, eHB, wHB;
    //public GameObject projectile = new GameObject();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //nHB = GameObject.Find("nHb");
        //sHB = GameObject.Find("sHb");
        //eHB = GameObject.Find("eHb");
        //wHB = GameObject.Find("wHb");

        //projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses W, A, S, or D, they move.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            float mHor = Input.GetAxis("Horizontal");

            float mVer = Input.GetAxis("Vertical");

            Vector2 moveVec = new Vector2(mHor, mVer);
        //transform(moveVec);
        rb.AddForce(moveVec * speed);
        }

        //Player attacks with the arrow keys
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Rigidbody pP = Instantiate(projectile, rb.transform.position, rb.transform.rotation);
            //Instantiate(bullet,transform.position, Quaternion.identity);
            wHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            eHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            sHB.SetActive(true);
        }
        //If they aren't attacking, the hitbox is disabled.
        else
        {
            wHB.SetActive(false);
            eHB.SetActive(false);
            nHB.SetActive(false);
            sHB.SetActive(false);

        }
        //When the player dies it will set their health to 0 to prevent healthbars 
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            this.enabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Debug.Log("bruh");
            health -= eDamage;
        }
    }

}

