using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameManager : MonoBehaviour
{
    public static Sc_GameManager Instance { get; private set; }

    private int currentLevel, currentScene;
    [SerializeField]
    [Tooltip("In seconds")]
    private float maxTimeInLevel;
    private float currentLevelTimer;

    private float levelTime;

    private GameObject player;

    private GameObject[] appearedTiles = new GameObject[3];

    private float tileDistanceFront, tileDistanceBack;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        currentScene++;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene);
        player = GameObject.FindGameObjectWithTag("Player");
        yield return null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
