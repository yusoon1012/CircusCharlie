using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndScrollLion : MonoBehaviour
{
    public GameObject lion;
    public bool isScrollEnd = false;
    public bool isLionMove = false;
    public Animator endlionAni;

    private float moveTimer = 0;
    private float moveRate = 10f;
    private float jumpTimer = 0;
    private float jumpRate = 2;
    private float speed = 3f;
    private bool isjump;
    EndingScroll endscroll;
    // Start is called before the first frame update
    void Start()
    {
        endscroll=GameObject.FindAnyObjectByType<EndingScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (endscroll.isScrolling==false && endscroll.isFirst == false)
        {
            moveTimer += Time.deltaTime;
        }

        if(moveTimer>=moveRate)
        {
            isLionMove = false;
        }
        else
        {

            isLionMove=true;
        }

        if(isLionMove==true&&endscroll.isFirst==false&& endscroll.isScrolling == false)
        {

            transform.position += Vector3.right * Time.deltaTime*speed;
        }
        
        

        endlionAni.SetBool("Move", isLionMove);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
