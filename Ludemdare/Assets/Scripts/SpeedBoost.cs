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
        PlayerMove move = target.GetComponent<PlayerMove>();
        if (target.tag == "Player")
        {
            move.move_Speed += boost_Amount;
            move.PlayAudio(0);
            move.tempSpeedBoostMethod();
        }
    }
}
