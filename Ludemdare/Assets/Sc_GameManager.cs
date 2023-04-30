using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameManager : MonoBehaviour
{
    public Sc_GameManager Instance { get; private set; }

    private int currentLevel, currentScene;
    [SerializeField]
    [Tooltip("In seconds")]
    private float maxTimeInLevel;
    private float currentLevelTimer;

    [SerializeField]
    private GameObject player, tile;

    [SerializeField]
    private GameObject[] currentNodes, playerNodes;

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
        StartCoroutine(SpawnTiles());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        currentScene++;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene);
        StartCoroutine(StartLevelTimer());
    }

    IEnumerator StartLevelTimer()
    {
        yield return new WaitForSeconds(maxTimeInLevel + (15 * currentScene));
        StartCoroutine(EndOfLevel());
        yield return null;
    }

    IEnumerator SpawnTiles()
    {
        for (int i = 0; i < currentNodes.Length; i++)
        {
            Instantiate(tile, currentNodes[i].transform);
        }
        StartCoroutine(TileCheck());
        yield return null;
    }

    IEnumerator TileCheck()
    {
        for (int i = 0; i < currentNodes.Length; i++)
        {
            tileDistanceFront = Vector2.Distance(currentNodes[i].transform.position, playerNodes[3].transform.position);
            tileDistanceBack = Vector2.Distance(currentNodes[i].transform.position, playerNodes[4].transform.position);
            if (tileDistanceFront < 10)
            {
                currentNodes[i].transform.position = playerNodes[2].transform.position;
            }
            if(tileDistanceBack < 10)
            {
                currentNodes[i].transform.position = playerNodes[0].transform.position;
            }
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(TileCheck());
        yield return null;
    }

    IEnumerator EndOfLevel()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(currentScene++);
        yield return null;
    }
}
