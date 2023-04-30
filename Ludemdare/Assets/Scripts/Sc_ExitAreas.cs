using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_ExitAreas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Sc_AIDirector.Instance.EnemyDeid();
            Destroy(collision.gameObject);
        }
    }
}
