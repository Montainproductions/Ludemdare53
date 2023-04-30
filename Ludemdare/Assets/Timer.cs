using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Seconds.ToString();
        if (currentTime <= 0) 
        {
            Debug.Log("Next level");
        }
    }
}
