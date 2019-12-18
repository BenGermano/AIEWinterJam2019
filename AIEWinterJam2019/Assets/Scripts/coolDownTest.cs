using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolDownTest : MonoBehaviour
{
    public float coolDown = 100;
    public float maxDelay = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && coolDown <= 0)
        {
            Debug.Log("Swaos");
            coolDown = maxDelay;
        }

        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        //else
        //{
            //coolDown = maxDelay;
        //}
    }
}
