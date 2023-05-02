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
        NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Sc_GameManager.Instance.currentScene == 0) return;
        if(currentTime <= 0)
        {
            Sc_UICanves.instance.PlayerWin();
        }

        currentTime -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        //Debug.Log(currentTime % 11);

        if ((currentTime % 11) < 0.001)
        {
            int powerUpValue = UnityEngine.Random.Range(0, 3);
            Sc_MainLevel.Instance.SpawnPowerUp(powerUpValue);
        }

        if (time.Seconds >= 0 && time.Seconds < 10)
        {
            currentTimeText.text = time.Minutes.ToString() + ":" + "0" + time.Seconds.ToString();
        }
        else 
        {
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }

    public void NewLevel()
    {
        if(currentLevel == 3)
        {
            EndGame();
        }
        currentLevel++;
        currentTime = startMinutes * 60 + 15 * currentLevel;
    }

    public void EndGame()
    {

    }

}
