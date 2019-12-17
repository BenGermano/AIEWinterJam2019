using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    public PlayerScript pS;
    private int maxHeartAmount = 3;
    public int curHearts;
    public int hPMax =  3;
    public GameObject[] hP;
    // Start is called before the first frame update
    void Start()
    {
        curHearts = pS.health;

        //for(int i = 0; i < hPCounter; i++)
        //{
        //    hP[i] = gameObject.GetComponent<GameObject>();
        //}
    }

    public void checkHealthAmount()
    {
        curHearts = pS.health;
        for(int i = 0; i<maxHeartAmount; i++)
        {
            if(curHearts <= i)
            {
                hP[i].SetActive(false);

            }
            else
            {
                hP[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        curHearts = pS.health;
        switch (curHearts)
        {
            case 0:
                hP[0].SetActive(false);
                break;
            case 1:
                hP[1].SetActive(false);
                break;
            case 2:
                hP[2].SetActive(false);
                break;
            
        }

    }
}
