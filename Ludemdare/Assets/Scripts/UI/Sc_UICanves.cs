using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_UICanves : MonoBehaviour
{
    public static Sc_UICanves instance { get; private set; }

    [SerializeField]
    private GameObject loseScreen, winScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void PlayerWin()
    {
        winScreen.SetActive(true);
    }

    public void PlayerDeath()
    {
        loseScreen.SetActive(true);
    }
}
