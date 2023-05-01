using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "PowerUps/Extra_Life")]
public class Extra_Life : PowerUpEffect
{
    public int num_lives = 1;

    public void Start()
    {
        
    }

    public override void Apply(GameObject target)
    {
        PlayerDamage dmg= target.GetComponent<PlayerDamage>();
        if (target.tag == "Player")
        {
            dmg.playerLives += num_lives;
            dmg.PlayAudio(0);
            UIManager.instance.ChangeLives(dmg.playerLives);
        }
    }
}
