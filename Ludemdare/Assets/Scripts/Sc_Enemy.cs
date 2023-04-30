using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Sc_Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameObject player;

    [SerializeField]
    private Transform walkingLocation;

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
    
    /*public void InitiializeCrash()
    {
        Debug.Log("Starting Crash");
        movingForward = false;
        Crash();
    }

    public void Crash()
    {
        Debug.Log("Crashing");
        currentRoute++;
        toLocation = rotationRoute.transform.GetChild(currentRoute);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ebug.Log(collision);
        //Debug.Log(collision.tag);
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerDamage>().PlayerHit();
            Destroy(gameObject);
        }
        else if (collision.tag == "Spawner")
        {
        }
    }
}
