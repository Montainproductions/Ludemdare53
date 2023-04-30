using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Extra_Life")]
public class Extra_Life : PowerUpEffect
{
    public float num_lives = 1f;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerDamage>().playerLives += num_lives;
    }
}
