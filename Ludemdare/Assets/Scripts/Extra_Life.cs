using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUPs/Extra_Life")]
public class Extra_Life : PowerUpEffect
{
    public float num_lives = 1f;
    public override void Apply(GameObject target) 
    { 
        target.GetComponent<Extra_Life>().num_lives += num_lives;
    }
}
