using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Invincibilty")]
public class Invincibilty : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerInvincibility>();
    }
}
