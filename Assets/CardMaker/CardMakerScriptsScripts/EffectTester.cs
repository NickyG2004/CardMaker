using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTester : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<Card>().CardLoseEffects();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Card>().CardWinEffects();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Card>().Destroycard();
        }
    }
}
