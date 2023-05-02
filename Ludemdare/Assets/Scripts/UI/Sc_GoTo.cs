using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GoTo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] currentUI;
    [SerializeField]
    private Transform[] newCurrentUIPos;

    public void OnClick()
    {
        StartCoroutine(ActivateNewUI());
    }

    IEnumerator ActivateNewUI()
    {
        yield return new WaitForSeconds(1.1f);
        currentUI[0].transform.position = newCurrentUIPos[0].position;
        currentUI[1].transform.position = newCurrentUIPos[1].position;
        yield return null;
    }
}
