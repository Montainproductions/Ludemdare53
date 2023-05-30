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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Sc_GameManager.Instance.currentScene == 0) return;

        if(currentTime <= 0)
        {
            Sc_MainLevel.Instance.NewLevel();
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

    public void NewTime(int currentLevelInt)
    {
        currentTime = startMinutes * 60 + 15 * currentLevelInt;
    }
}
