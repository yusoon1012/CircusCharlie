using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonkeyJump : MonoBehaviour
{
    private bool isMonkeyJump=false;
    private float jumpForce = 30f;
    Rigidbody2D monkeyRigid;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        monkeyRigid=GetComponent<Rigidbody2D>();
        playerController=GameObject.FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isPlayerDie==true)
        {
            return;
         }

        if (isMonkeyJump==true)
        {
            monkeyRigid.velocity = Vector2.zero;
            monkeyRigid.AddForce(new Vector2(0f, jumpForce));
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("MonkeyJump"))
        {
            isMonkeyJump = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("MonkeyJump"))
        {
            isMonkeyJump = false;
        }
    }
}
