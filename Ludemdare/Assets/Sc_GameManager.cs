using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player, tile;

    [SerializeField]
    private GameObject[] currentNodes, playerNodes;

    private GameObject[] appearedTiles = new GameObject[3];

    private float tileDistanceFront, tileDistanceBack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTiles());
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if (tileDistanceFront < 5)
            {
                currentNodes[i].transform.position = playerNodes[2].transform.position;
            }
            if(tileDistanceBack < 5)
            {
                currentNodes[i].transform.position = playerNodes[0].transform.position;
            }
        }
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(TileCheck());
        yield return null;
    }

    IEnumerator DistanceFromNode()
    {

        yield return null;
    }
}
