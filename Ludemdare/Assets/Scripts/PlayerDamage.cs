using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMovement;

    private Rigidbody2D enemy_body;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("10 points");
            StartCoroutine(HitEnemy());
           
        }
    }

    IEnumerator HitEnemy() {
        float move_Speed = playerMovement.move_Speed;
        playerMovement.move_Speed = 8;
        yield return new WaitForSeconds(1.5f);
        playerMovement.move_Speed = 15;
        yield return null;

    }

}
