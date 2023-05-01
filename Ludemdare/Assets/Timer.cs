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

    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0)
        {
            NewLevel();
        }

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

    public float NewLevel()
    {
        currentLevel++;
        currentTime = startMinutes * 60 + 15 * currentLevel;
        return currentTime;
    }

}
