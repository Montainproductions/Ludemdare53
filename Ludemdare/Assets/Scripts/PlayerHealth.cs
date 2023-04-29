using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerLives = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives: " + playerLives);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Lives: " + playerLives);
        if (playerLives == 0f) 
        {
            Debug.Log("Game Over");
        }
    }
}
