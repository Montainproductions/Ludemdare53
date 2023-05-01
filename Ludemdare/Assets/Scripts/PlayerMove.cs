using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour { 

    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;


    public float move_Speed;

    public AudioSource src;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        move_Speed = 15f;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxis("Horizontal"); // -1 is left
        vertical = Input.GetAxis("Vertical"); // -1 is down
        //Debug.Log(horizontal);
        //Debug.Log(vertical);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
            //Debug.Log(horizontal);
            //Debug.Log(vertical);
        }
        
 

        body.velocity = new Vector2(horizontal * move_Speed, vertical * move_Speed);
    }

    public void tempSpeedBoostMethod() 
    {
        StartCoroutine(tempSpeedBoost());
    }

    IEnumerator tempSpeedBoost() 
    {
        yield return new WaitForSeconds(3f);
        move_Speed = 15;
        yield return null;
    }

    public void PlayAudio(int i)
    {
        src.PlayOneShot(clip[i]);
    }
}
