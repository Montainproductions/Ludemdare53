using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_UICanves : MonoBehaviour
{
    public static Sc_UICanves Instance { get; private set; }

    [SerializeField]
    private GameObject loseScreen, winScreen;

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

    public void RestartLevel()
    {
        loseScreen.SetActive(false);
        Sc_MainLevel.Instance.StartNewGame();
    }
}
