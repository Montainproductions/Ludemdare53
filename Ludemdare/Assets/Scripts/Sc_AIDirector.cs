using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_AIDirector : MonoBehaviour
{
    public static Sc_AIDirector Instance { get; private set; }

    private int posToSpawn;

    [SerializeField]
    private GameObject[] enemyOptions, spawnLocations, warningSigns;

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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int sideOfScreen;
        int enemyToSpawn;
        if (Sc_MainLevel.Instance.ReturnCurrentLevel() == 1)
        {
            enemyToSpawn = 0;
            sideOfScreen = Random.Range(0, 1);
        }
        else if(Sc_MainLevel.Instance.ReturnCurrentLevel() == 2)
        {
            enemyToSpawn = 1;
            sideOfScreen = 2;
        }
        else
        {
            sideOfScreen = Random.Range(0, 2);
            if(sideOfScreen < 2)
            {
                enemyToSpawn = 2;
            }
            else
            {
                enemyToSpawn = 3;
            }
        }
        Sc_SpawnerTimer spawnerTimer, oppositeTimer;
        //0,1,2, 3,4,5, 6,7,
        if (sideOfScreen == 0)
        {
            posToSpawn = Random.Range(0, 2);
            spawnerTimer = spawnLocations[posToSpawn].GetComponent<Sc_SpawnerTimer>();
            oppositeTimer = spawnLocations[posToSpawn + 4].GetComponent<Sc_SpawnerTimer>();
            if (!spawnerTimer.spawnerBeenUsed)
            {
                Transform location = spawnLocations[posToSpawn].transform;
                StartCoroutine(spawnerTimer.SpawnerUsed());
                StartCoroutine(oppositeTimer.SpawnerUsed());
                warningSigns[posToSpawn].SetActive(true);
                yield return new WaitForSeconds(1.2f);
                warningSigns[posToSpawn].SetActive(false);
                Instantiate(enemyOptions[enemyToSpawn], location.position, location.rotation);
            }
        }
        else if (sideOfScreen == 1)
        {
            posToSpawn = Random.Range(0, 2);
            spawnerTimer = spawnLocations[posToSpawn + 4].GetComponent<Sc_SpawnerTimer>();
            oppositeTimer = spawnLocations[posToSpawn].GetComponent<Sc_SpawnerTimer>();
            if (!spawnerTimer.spawnerBeenUsed)
            {
                Transform location = spawnLocations[posToSpawn + 4].transform;
                StartCoroutine(spawnerTimer.SpawnerUsed());
                StartCoroutine(oppositeTimer.SpawnerUsed());
                warningSigns[posToSpawn + 4].SetActive(true);
                yield return new WaitForSeconds(1.2f);
                warningSigns[posToSpawn + 4].SetActive(false);
                Instantiate(enemyOptions[enemyToSpawn], location.position, location.rotation);
            }
        }
        else if (sideOfScreen == 2)
        {
            posToSpawn = Random.Range(0, 1);
            spawnerTimer = spawnLocations[posToSpawn + 6].GetComponent<Sc_SpawnerTimer>();
            if (!spawnerTimer.spawnerBeenUsed)
            {
                Transform location = spawnLocations[posToSpawn + 6].transform;
                StartCoroutine(spawnerTimer.SpawnerUsed());
                warningSigns[posToSpawn + 6].SetActive(true);
                yield return new WaitForSeconds(1.2f);
                warningSigns[posToSpawn + 6].SetActive(false);
                Instantiate(enemyOptions[enemyToSpawn], location.position, location.rotation);
            }
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnEnemy());
        yield return null;
    }
}