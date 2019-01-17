using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{

    public float lifeTime = 4.0f;
    private float timeLeft;
    public Image cdImage;
    public float baseValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        cdImage.fillAmount = timeLeft / lifeTime;

        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetValue()
    {
        return baseValue * (timeLeft/lifeTime);
    }
}
