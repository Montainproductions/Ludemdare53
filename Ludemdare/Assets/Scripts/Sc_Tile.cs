using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Tile : MonoBehaviour
{
    [HideInInspector]
    public Transform walkingLocation;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(walkingLocation.position, gameObject.transform.position) > 1)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
