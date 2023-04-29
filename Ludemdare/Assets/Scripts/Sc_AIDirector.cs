using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_AIDirector : MonoBehaviour
{
    //The player input system
    private PlayerInput playerInputActions;

    [SerializeField]
    private float maxStressLevel, maxEnemies;
    private float stressLevel, currentEnemies;
    private int posToSpawn;

    [SerializeField]
    private GameObject[] enemyOptions;
    [SerializeField]
    private Transform[] spawnLocations;
    private GameObject[] enemiesOnScreen, enemiesOffScreen;

    private void Awake()
    {
        playerInputActions = new PlayerInput();
        playerInputActions.Player.Enable();
        playerInputActions.Player.NewEnemy.performed += SpawnEnemy_Preformed;
    }

    // Start is called before the first frame update
    void Start()
    {
        stressLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stressLevel < maxStressLevel)
        {

        }
    }

    IEnumerator SpawnEnemy()
    {
        int enemyToSpawn = Random.Range(0, enemyOptions.Length);
        int sideOfScreen = Random.Range(0, 3);
        //0,1,2, 3,4,5, 6,7, 8,9
        if(sideOfScreen == 0)
        {
            posToSpawn = Random.Range(0, 2);
            Transform location = spawnLocations[posToSpawn];
            //Debug.Log(posToSpawn);
            Instantiate(enemyOptions[0], location);
        }
        else if(sideOfScreen == 1)
        {
            posToSpawn = Random.Range(0, 2);
            Transform location = spawnLocations[posToSpawn + 4];
            //Debug.Log(posToSpawn + 3);
            Instantiate(enemyOptions[0], location);
        }
        else if (sideOfScreen == 2)
        {
            posToSpawn = Random.Range(0, 1);
            Transform location = spawnLocations[posToSpawn + 6];
            //Debug.Log(posToSpawn + 6);
            Instantiate(enemyOptions[0], location);
        }
        else
        {
            posToSpawn = Random.Range(0, 1);
            Transform location = spawnLocations[posToSpawn + 8];
            //Debug.Log(posToSpawn + 8);
            Instantiate(enemyOptions[0], location);
        }
        yield return null;
    }

    public void SpawnEnemy_Preformed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        StartCoroutine(SpawnEnemy());
    }
}

class CarRoute
{
    private Transform[] setOfRoute;
    private int currentDestinationint;
    private Transform currentDestination;

    public CarRoute(Transform[] route)
    {
        setOfRoute = new Transform[4];
        setOfRoute = route;
        currentDestinationint = 0;
    }

    public void RestartRoute()
    {
        currentDestinationint = 0;
    }
} 