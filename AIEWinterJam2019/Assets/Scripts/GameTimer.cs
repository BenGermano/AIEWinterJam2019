using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // THIS NEEDS TO BE THE SCRIPT COMPONENT OFF OF THE PLAYER.
    // Not the script itself.
    public PlayerScript currentPlayersScript;
    public Text text;

    float startTime;
    float ellapsedTime;

    void Start()
    {
        // Start time is set to the current time.
        startTime = Time.time;
    }

    void Update()
    {
        // As long as the player is alive: ellapsedTime is changed accordingly.
        if (currentPlayersScript.health > 0)
        {
            ellapsedTime = Time.time - startTime;
            text.text = "Time: " + ellapsedTime.ToString("0.00");
        }
    }
}
