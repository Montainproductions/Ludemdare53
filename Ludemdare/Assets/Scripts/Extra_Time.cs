using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Extra_Time")]
public class Extra_Time : PowerUpEffect
{
    public float time_amount = 5f;
    public override void Apply(GameObject target) 
    {
        target.GetComponent<PlayerMove>().AddTime(time_amount);
        target.GetComponent<PlayerMove>().PlayAudio(1);
    }
}
