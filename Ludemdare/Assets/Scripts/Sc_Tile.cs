using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Tile : MonoBehaviour
{
    [HideInInspector]
    public Transform walkingLocation;

    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(walkingLocation.position, gameObject.transform.position) > 1)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Sc_GameManager.Instance.SpawnTile());
            Destroy(gameObject);
        }
    }
}
