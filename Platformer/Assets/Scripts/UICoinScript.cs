using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoinScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public int totalNumberOfCoins { get; set; }

    private int numberOfCoinsCollected = 0;
    

    private void Start()
    {
        text.text = numberOfCoinsCollected + "/" + totalNumberOfCoins;
    }

    public void SetText()
    {
        numberOfCoinsCollected++;
        text.text = numberOfCoinsCollected + "/" + totalNumberOfCoins;
    }
}
