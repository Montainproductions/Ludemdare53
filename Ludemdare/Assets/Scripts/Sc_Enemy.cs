using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameObject player;
    private PlayerDamage playerDamageScript;

    [SerializeField]
    private Transform walkingLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDamageScript = player.GetComponent<PlayerDamage>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ebug.Log(collision);
        //Debug.Log(collision.tag);
        if (collision.gameObject.tag == "Player" && !playerDamageScript.recentlyHit)
        {
            playerDamageScript.PlayerHit();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Spawner"))
        {
        }
    }
}
