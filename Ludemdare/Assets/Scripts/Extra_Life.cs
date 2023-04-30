using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Extra_Life")]
public class Extra_Life : PowerUpEffect
{
    public int num_lives = 1;
    public override void Apply(GameObject target)
    {
        if (target.tag == "Player")
        {
            target.GetComponent<PlayerDamage>().playerLives += num_lives;
        }
    }
}
