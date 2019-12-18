using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 0;
    public float seedSpeed = 10;
    public int health = 100;
    public int eDamage = 10;
    public int pDamage = 10;
    public float coolDown = 5, maxDelay = 5;
    public Rigidbody2D rb;
    public GameObject bullet;
    public GameObject nHB, sHB, eHB, wHB;
    public HealthCounter hC;
    //public GameObject projectile = new GameObject();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nHB.SetActive(false);
        eHB.SetActive(false);
        sHB.SetActive(false);
        wHB.SetActive(false);

        //hC.checkHealthAmount();
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

        //Player attacks with a combination of movement keys + E.
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.A))
        {
            wHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.D))
        {
            eHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            nHB.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.S))
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

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && coolDown <= 0)
        {
            GameObject pP = Instantiate(bullet, transform.position + transform.up * 0.3f, Quaternion.identity);
            pP.transform.right = Vector3.up;
            pP.GetComponent<Rigidbody2D>().AddForce(transform.up * seedSpeed);
            coolDown = maxDelay;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A) && coolDown <= 0)
        {
            GameObject pP = Instantiate(bullet, transform.position + transform.right * -0.25f, Quaternion.Euler(0,180,0));
            pP.GetComponent<Rigidbody2D>().AddForce(transform.right * -seedSpeed);
            coolDown = maxDelay;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S) && coolDown <= 0)
        {
            GameObject pP = Instantiate(bullet, transform.position + transform.up * -0.2f, Quaternion.identity);
            pP.transform.right = Vector3.down;
            pP.GetComponent<Rigidbody2D>().AddForce(transform.up * -seedSpeed);
            coolDown = maxDelay;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D) && coolDown <= 0)
        {
            GameObject pP = Instantiate(bullet, transform.position + transform.right * 0.25f, Quaternion.identity);
            pP.GetComponent<Rigidbody2D>().AddForce(transform.right * seedSpeed);
            coolDown = maxDelay;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && coolDown <= 0)
        {
            GameObject pP = Instantiate(bullet, transform.position + transform.up * -0.2f, Quaternion.identity);
            pP.transform.right = Vector3.down;
            pP.GetComponent<Rigidbody2D>().AddForce(transform.up * -seedSpeed);
            coolDown = maxDelay;
        }
        //When the player dies it will set their health to 0 to prevent healthbars from going into the negatives.
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene("GameOver");
            this.enabled = false;
        }

        //
        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            //Debug.Log("bruh");
            health -= eDamage;
        }
    }

}

