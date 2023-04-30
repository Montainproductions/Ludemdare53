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

    private Renderer rend;
    private Color newColour = Color.red;
    private Color oldColour = Color.white;

    public float playerLives = 3f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives == 0f)
        {
            Debug.Log("Game Over");
        }
    }

    public void PlayerHit()
    {
        Debug.Log("Hello");
        StartCoroutine(ChangeColors());
        StartCoroutine(PlayerHitCoroutine());
    }

    IEnumerator PlayerHitCoroutine() {
        float move_Speed = playerMovement.move_Speed;
        playerMovement.move_Speed = 8;
        playerLives -= 1;
        Debug.Log(playerLives);
        yield return new WaitForSeconds(1.5f);
        playerMovement.move_Speed = 15;
        yield return null;
    }
    IEnumerator ChangeColors()
    {
        rend.material.color = newColour;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = oldColour;
        yield return null;
    }
}
