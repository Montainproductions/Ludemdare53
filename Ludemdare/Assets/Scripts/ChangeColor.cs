using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer rend;
    private Color newColour = Color.red;
    private Color oldColour = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeColors());

        }
    }

    IEnumerator ChangeColors()
    {
        rend.material.color = newColour;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = oldColour;
        yield return null;

    }
}
