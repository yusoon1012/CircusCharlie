using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;

public class EndingScroll : MonoBehaviour
{
    public GameObject endScroll;
    private float scrollTimer = 0f;
    private float scrollRate = 3f;
    public bool isScrolling = default;
    public bool isFirst = true;
    private float firstTimer = 0f;
    private float firstRate = 3f;
   
    // Start is called before the first frame update
    void Start()
    {
        isFirst=true;
        


    }

    // Update is called once per frame
    void Update()
    {
        if(isFirst==true)
        {
            firstTimer += Time.deltaTime;
        }
        if(firstTimer>=firstRate)
        {
            isFirst = false;
        }


        


        if(isFirst==false)
        {
        scrollTimer += Time.deltaTime;

        }
        if(scrollTimer>=scrollRate)
        {
            isScrolling = false;
        }
        else
        {
            isScrolling = true;
        }
        if(isScrolling==true&&isFirst==false)
        {
            endScroll.transform.position += Vector3.up * Time.deltaTime;

        }
       

    }
}
