using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GoTo : MonoBehaviour
{
    [SerializeField]
    private GameObject currentUI, targetUI, currentUIObj;
    [SerializeField]
    private Transform newCurrentUIPos, newTargetUIPos;

    public void OnClick()
    {
        StartCoroutine(ActivateNewUI());
    }

    IEnumerator ActivateNewUI()
    {
        yield return new WaitForSeconds(1.1f);
        currentUI.transform.position = newCurrentUIPos.position;
        targetUI.transform.position = newTargetUIPos.position;
        yield return null;
    }
}
