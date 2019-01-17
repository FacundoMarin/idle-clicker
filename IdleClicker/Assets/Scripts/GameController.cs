using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{   

    public TextMeshProUGUI text;
    private float coins;

    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCoins(float value)
    {
        coins += value;
        UpdateText();
    }

    private void UpdateText()
    {
        text.SetText("Sweet Money: " + coins.ToString("F2") + "$");
    }
}
