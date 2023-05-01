using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_MainLevel : MonoBehaviour
{
    public static Sc_MainLevel Instance { get; private set; }

    [SerializeField]
    private GameObject[] tile;

    [SerializeField]
    private GameObject[] currentNodes;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SpawnTile();
    }

    public void SpawnTile()
    {
        int tilePos = Random.Range(0, tile.Length);
        GameObject newTile = Instantiate(tile[tilePos], currentNodes[0].transform);
        newTile.GetComponent<Sc_Tile>().walkingLocation = currentNodes[1].transform;
    }
}
