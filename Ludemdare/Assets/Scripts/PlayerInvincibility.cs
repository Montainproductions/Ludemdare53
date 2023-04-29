using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    private bool invincibleEnabled;
    // Start is called before the first frame update
 

    public void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (invincibleEnabled == false) 
            {
                Destroy(gameObject);
 
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
