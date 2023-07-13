using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    GameObject blinkObject;
    float blinkTimer = 0;
    float blinkRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        blinkObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer += Time.deltaTime;
        if(blinkTimer>=blinkRate)
        {
            blinkTimer = 0;
            blinkObject.SetActive(false);

        }
        else
        {
        blinkObject.SetActive(true);

        }
    }
}
