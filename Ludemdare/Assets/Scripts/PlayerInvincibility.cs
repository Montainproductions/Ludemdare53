using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInvincibility : MonoBehaviour
{
    public bool invincibleEnabled = false;
    [SerializeField]
    private float invincDuration = 3.0f;
    // Start is called before the first frame update
    public AudioSource src;
    public AudioClip[] clip;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (invincibleEnabled == true) 
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void InvincEnabled() 
    { 
        invincibleEnabled = true;
        StartCoroutine(InvincDisableRoutine());
    }

    IEnumerator InvincDisableRoutine() 
    {
        yield return new WaitForSeconds(invincDuration);
        invincibleEnabled = false;
        yield return null;
    }

    public void PlayAudio(int i)
    {
        src.PlayOneShot(clip[i]);
    }
}
