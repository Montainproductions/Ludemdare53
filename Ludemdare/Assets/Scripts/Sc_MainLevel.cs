using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_MainLevel : MonoBehaviour
{
    public static Sc_MainLevel Instance { get; private set; }

    private int currentLevel;

    [SerializeField]
    private GameObject[] tile, currentNodes, powerUpTileSpawn, powerUps;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnTile();
        NewLevel();
    }

    public void SpawnPowerUp(int powerUpValue)
    {
        int spawnLocation = Random.Range(0, powerUpTileSpawn.Length);
        Instantiate(powerUps[powerUpValue], powerUpTileSpawn[spawnLocation].transform);
    }

    public void SpawnTile()
    {
        int tilePos = Random.Range(0, tile.Length);
        GameObject newTile = Instantiate(tile[tilePos], currentNodes[0].transform);
        newTile.GetComponent<Sc_Tile>().walkingLocation = currentNodes[1].transform;
    }

    public void StartNewGame()
    {
        currentLevel = 0;
        Timer.Instance.NewTime(currentLevel);
    }

    public void NewLevel()
    {
        if (currentLevel == 3)
        {
            EndGame();
        }
        currentLevel++;

        Timer.Instance.NewTime(currentLevel);
    }

    public void EndGame()
    {
        Sc_UICanves.Instance.PlayerWin();
    }

    public int ReturnCurrentLevel()
    {
        return currentLevel;
    }
}
