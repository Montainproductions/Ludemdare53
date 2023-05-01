using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    public int currentLevel;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        currentTime = NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0)
        {
            currentTime = NewLevel();
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
    }

    public float NewLevel()
    {
        if(currentLevel == 3)
        {
            EndGame();
        }
        currentLevel++;
        float newLevelTime = startMinutes * 60 + 15 * currentLevel;
        return newLevelTime;
    }

    public void EndGame()
    {

    }

}
