using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBoost")]
public class SpeedBoost : PowerUpEffect
{
    public float boost_Amount;
    public float boost_duration;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMove>().move_Speed += boost_Amount;
        target.GetComponent<PlayerMove>().tempSpeedBoostMethod();
    }
}
