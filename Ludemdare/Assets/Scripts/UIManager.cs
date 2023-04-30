using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; set; }
    
    [SerializeField]
    private GameObject[] lives;

    [SerializeField]
    private Transform lifeParent;

    [SerializeField]
    private GameObject lifePrefab;

    public void Awake()
    {
        instance = this;
    }

    public void ChangeLives(int amount) 
    {
        Debug.Log(amount);
        for (int i = 0; i < 4; i++) 
        {
            if (i < amount)
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }
    }

}
