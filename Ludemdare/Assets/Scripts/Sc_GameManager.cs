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

    [SerializeField]
    private GameObject tile;

    [SerializeField]
    private GameObject[] currentNodes;

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
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnTile()
    {
        GameObject newTile = Instantiate(tile, currentNodes[0].transform);
        newTile.GetComponent<Sc_Tile>().walkingLocation = currentNodes[1].transform;
    }

    public void StartGame()
    {
        currentScene++;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene);
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StartLevelTimer());
    }

    IEnumerator StartLevelTimer()
    {
        levelTime = maxTimeInLevel + (15 * currentScene);
        yield return new WaitForSeconds(levelTime);
        StartCoroutine(EndOfLevel());
        yield return null;
    }

    IEnumerator EndOfLevel()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene++);
        yield return null;
    }
}
