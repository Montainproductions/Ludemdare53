using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInvincibility : MonoBehaviour
{
    public bool invincibleEnabled = false;

    [SerializeField]
    private GameObject uiForInvic;

    [SerializeField]
    private float invincDuration = 4.0f;
    
    public AudioSource src;
    public AudioClip[] clip;

    private void Start()
    {
        uiForInvic.SetActive(false);
    }

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
        uiForInvic.SetActive(true);
        uiForInvic.GetComponent<Sc_InvisUI>().RestartValue();
        StartCoroutine(InvincDisableRoutine());
    }

    IEnumerator InvincDisableRoutine() 
    {
        yield return new WaitForSeconds(invincDuration);
        invincibleEnabled = false;
        uiForInvic.SetActive(false);
        yield return null;
    }

    public void PlayAudio(int i)
    {
        src.PlayOneShot(clip[i]);
    }
}
