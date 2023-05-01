using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public float currentTime;
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
        Debug.Log(time);
        if (time.Seconds >= 0 && time.Seconds < 10)
        {
            currentTimeText.text = time.Minutes.ToString() + ":" + "0" + time.Seconds.ToString();
        }
        else 
        {
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
     
        if (currentTime <= 0) 
        {
            Start();
            Debug.Log("Next level");
        }
    }

}
