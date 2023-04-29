using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;

    [SerializeField]
    private GameObject[] currentNodes;

    private GameObject[] appearedTiles = new GameObject[3];

    private float tileDistance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TileCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TileCheck()
    {
        for (int i = 0; i < currentNodes.Length; i++)
        {
            if(appearedTiles[i] == null)
            {
                appearedTiles[i] = Instantiate(tile, currentNodes[i].transform);
            }
            else
            {
                tileDistance = Vector2.Distance(currentNodes[i].transform.position, appearedTiles[i].transform.position);
                if (tileDistance > 12)
                {
                    appearedTiles[i] = null;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(TileCheck());
        yield return null;
    }

    IEnumerator DistanceFromNode()
    {

        yield return null;
    }
}
