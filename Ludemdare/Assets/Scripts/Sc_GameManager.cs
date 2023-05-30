using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameManager : MonoBehaviour
{
    public static Sc_GameManager Instance { get; private set; }

    [HideInInspector]
    public int currentScene;

    [SerializeField]
    [Tooltip("In seconds")]
    private float maxTimeInLevel;

    private GameObject player;

    public GameObject mainMenu, mainGame, Pause_Menu;
    private bool paused;



    public void Awake()
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

        paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = 0;
    }

    public void Update()
    {
        if (currentScene == 0)
        {
            mainMenu.SetActive(true);
            mainGame.SetActive(false);
            Pause_Menu.SetActive(false);
        }
        else if(currentScene != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            //mainMenu.SetActive(false);
            PauseMenu();
        }
        else if (currentScene != 0)
        {
            mainMenu.SetActive(false);
            mainGame.SetActive(true);
        }
        Debug.Log(currentScene);
        
    }

    public void PauseMenu()
    {
        Debug.Log("Pause");
        paused = !paused;
        Pause_Menu.SetActive(paused);
        if (paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void NextLevel()
    {
        currentScene++;
    }

    public void MainMenu()
    {
        currentScene = 0;
        SceneManager.LoadScene(currentScene); ;
    }

    public void StartGameMethod()
    {
        Sc_MainLevel.Instance.StartNewGame();
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
        player = GameObject.FindGameObjectWithTag("Player");
        yield return null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
