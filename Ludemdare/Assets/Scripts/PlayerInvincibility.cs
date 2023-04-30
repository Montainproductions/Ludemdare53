using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    private bool invincibleEnabled;
    // Start is called before the first frame update
 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (invincibleEnabled == false) 
            {
                //Destroy(gameObject);
                Debug.Log("H");
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
        yield return new WaitForSeconds(3f);
        invincibleEnabled = false;
        yield return null;
    }
}
