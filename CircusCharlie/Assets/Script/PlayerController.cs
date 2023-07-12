using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;
using UnityEditor.SceneManagement;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 300f;
    GameObject playerObj;
    Player player;
    private int playerId = 0;
    private Rigidbody2D playerRigid = default;
    public Animator animator = default;
    public Animator lionAnimator = default;
    private AudioSource playerAudio = default;
    public bool isGround = false;
    public bool isJump = false;
    private bool isGoLeft = false;
    private bool isGoRight = false;
    public bool isPlayerDie = false;
    ScrollingObject scroll;
    StageController stage;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //lionAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerObj = GetComponent<GameObject>();

        stage = GameObject.FindAnyObjectByType<StageController>();
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDie == true)
        {
            return;
        }

        if (isJump == false)
        {
            lionAnimator.SetBool("Lion Jump", isJump);

            if (player.GetButtonDown("Player Jump") && isJump == false)
            {
                isJump = true;
                lionAnimator.SetBool("Lion Jump", isJump);

                playerRigid.velocity = Vector2.zero;
                playerRigid.AddForce(new Vector2(0, jumpForce));

            }

            if (player.GetButton("Player Left") && isGround == true)
            {

                isGoLeft = true;
                isGoRight = false;

            }

            else if (player.GetButton("Player Right"))
            {
                
                isGoRight = true;
                isGoLeft = false;


            }
            else
            {
                isGoRight = false;
                isGoLeft = false;
            }

        }
        else if (isJump == true)
        {

            
            isGoRight = false;
            isGoLeft = false;
        }


        
          lionAnimator.SetBool("Move Left", isGoLeft);
        lionAnimator.SetBool("Move Right", isGoRight);

        animator.SetBool("Move Right", isGoRight);
        animator.SetBool("Move Left", isGoLeft);


    }
    private void Die()
    {
        Debug.Log("Á×¾ú´Ù");
        animator.SetTrigger("Player Die");
        lionAnimator.SetTrigger("Player Die");
        playerRigid.velocity = Vector2.zero;
        playerRigid.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Floor"))
        {
            isGround = true;
            isJump = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("FireRing"))
        {

            isPlayerDie = true;
            Die();

        }
        if (collision.tag.Equals("Goal"))
        {
            isGround = true;
            isJump = false;
            playerRigid.velocity = Vector2.zero;
            Debug.Log("°ñÀÎ");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Floor"))
        {
            isGround = false;
        }

    }
}
