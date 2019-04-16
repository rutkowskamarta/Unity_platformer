using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class CoinBehaviour : MonoBehaviour
{

    private UICoinScript uiCoinScript;

    private void Awake()
    {
        uiCoinScript = GameObject.Find("CoinBar").GetComponent<UICoinScript>();
        uiCoinScript.totalNumberOfCoins++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            uiCoinScript.SetText();
            Destroy(gameObject);
        }
    }
}
