using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject pixelPanel;
    public GameObject pixel;
    public TextMeshProUGUI text;
    private int pixels;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPixel()
    {
        Instantiate(pixel, pixelPanel.transform);
        pixels++;
        text.text = "Pixel count: " + pixels; 
        
        
    }
}
