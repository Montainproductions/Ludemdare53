using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "PowerUps/Invincibilty")]
public class Invincibilty : PowerUpEffect
{
   
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerInvincibility>().InvincEnabled();
        target.GetComponent<PlayerInvincibility>().PlayAudio(0);
    }
}
