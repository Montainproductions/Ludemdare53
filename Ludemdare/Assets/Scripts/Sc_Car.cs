using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public class Sc_Car : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool movingForward;

    private GameObject player;

    [SerializeField]
    private GameObject[] rotate;
    private GameObject rotationRoute;
    private Transform toLocation;

    private int currentRoute;

    private float playerDistance, angleDifference;

    private bool notStartedCrash;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRoute = -1;
        movingForward = true;
        notStartedCrash = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        angleDifference = Vector2.Angle(player.transform.position, gameObject.transform.position);
        //Debug.Log("Player Distance: " + playerDistance);
        //Debug.Log("Player Angle: " + angleDifference);

        /*if (playerDistance < 5f && angleDifference < 30 && notStartedCrash)
        {
            InitiializeCrash();
        }*/

        if (movingForward)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            /*if (Vector2.Distance(toLocation.position, gameObject.transform.position) < 0.5f && currentRoute < 4) 
            { 
                Crash(); 
            }
            else
            {
                transform.Translate(toLocation.position * speed * Time.deltaTime);
            }*/
        }
    }

    public void InitiializeCrash()
    {
        Debug.Log("Starting Crash");
        rotationRoute = Instantiate(rotate[0], gameObject.transform, true);
        movingForward = false;
        notStartedCrash = false;
        Crash();
    }

    public void Crash()
    {
        Debug.Log("Crashing");
        currentRoute++;
        toLocation = rotationRoute.transform.GetChild(currentRoute);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ebug.Log(collision);
        //Debug.Log(collision.tag);

        if (collision.tag == "Otherside")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Player")
        {
            player.GetComponent<PlayerDamage>().PlayerHit();
            Destroy(gameObject);
        }
        else if(collision.tag == "Spawner")
        {
            Debug.Log("HitSpawner");
        }
    }
}
