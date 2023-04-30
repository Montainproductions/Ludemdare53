using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sc_SpawnerTimer : MonoBehaviour
{
    [HideInInspector]
    public bool spawnerBeenUsed;

    public void Start()
    {
        spawnerBeenUsed = false;
    }

    public IEnumerator SpawnerUsed()
    {
        spawnerBeenUsed = true;
        float timerWait = Random.Range(1.0f,3.0f);
        yield return new WaitForSeconds(timerWait);
        spawnerBeenUsed = false;
        yield return null;
    }
}
