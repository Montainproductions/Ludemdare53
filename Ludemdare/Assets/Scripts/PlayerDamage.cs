using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMovement;

    [SerializeField]
    private Renderer rend;
    private Color newColour = Color.red;
    private Color oldColour = Color.white;

    public bool recentlyHit;

    public int playerLives;

    public PlayerInvincibility invincibility; 

    public AudioSource src;
    public AudioClip[] clip;
    
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.ChangeLives(playerLives);
        recentlyHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0f)
        {
            Debug.Log("Game Over"); 
        }
    }

    public void PlayerDeath()
    {
        Sc_UICanves.Instance.PlayerDeath();
    }

    public void PlayerHit()
    {
        if (!recentlyHit && !invincibility.invincibleEnabled)
        {
            recentlyHit = true;
            StartCoroutine(ChangeColors());
            StartCoroutine(PlayerHitCoroutine());
            StartCoroutine(RecentlyHit());
        }
    }

    IEnumerator RecentlyHit()
    {
        yield return new WaitForSeconds(0.4f);
        recentlyHit = false;
        yield return null;
    }

    IEnumerator PlayerHitCoroutine() {
        float move_Speed = playerMovement.move_Speed;
        playerMovement.move_Speed = 8;
        playerLives -= 1;
        if(playerLives <= 0)
        {
            PlayerDeath();
        }
        UIManager.instance.ChangeLives(playerLives);
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

    public void PlayAudio(int i) 
    {
        src.PlayOneShot(clip[i]);
    }
}
