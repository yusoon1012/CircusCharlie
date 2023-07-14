using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;
using UnityEditor;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpclip;
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
    public bool isGoal = false;
    private bool isGoLeft = false;
    private bool isGoRight = false;
    public bool isPlayerDie = false;
    GameManager gameManager;
    private int jumpsoundCount=0;
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
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
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
            jumpsoundCount = 0;
            if (SceneManager.GetActiveScene().name == ("Stage1"))
            {
            lionAnimator.SetBool("Lion Jump", isJump);
                
            }
                animator.SetBool("Player Jump", isJump);

            if (player.GetButtonDown("Player Jump") && isJump == false)
            {
                isJump = true;
                if (SceneManager.GetActiveScene().name == ("Stage1"))
                {
                    lionAnimator.SetBool("Lion Jump", isJump);

                }

                    animator.SetBool("Player Jump", isJump);
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
           if(jumpsoundCount<1)
            { 
                playerAudio.PlayOneShot(jumpclip);
                jumpsoundCount += 1;
            }


            isGoRight = false;
            isGoLeft = false;
        }


            if (SceneManager.GetActiveScene().name == ("Stage1"))
        {
            lionAnimator.SetBool("Move Left", isGoLeft);
        lionAnimator.SetBool("Move Right", isGoRight);

        }

        animator.SetBool("Move Right", isGoRight);
        animator.SetBool("Move Left", isGoLeft);


    }
    private void Die()
    {
        PlayerInfo.playerHp -= 1;
        isPlayerDie = true;
        isJump = false;
        animator.SetBool("Player Jump",isJump);
        Debug.Log("Á×¾ú´Ù");
        animator.SetTrigger("Player Die");
        if(SceneManager.GetActiveScene().name=="Stage1")
        {
        lionAnimator.SetTrigger("Player Die");

        }
        gameManager.backgroundMusic.Stop();
        playerAudio.clip = deathClip;
        playerAudio.Play();
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
        if (collision.collider.tag.Equals("Goal"))
        {
            isGround = true;
            isJump = false;
            isGoal = true;
            playerRigid.velocity = Vector2.zero;
            animator.SetTrigger("Goal");
            Debug.Log("°ñÀÎ");
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead"))
        {

            isPlayerDie = true;
            Die();

        }
        if (collision.tag.Equals("Bonus"))
        {
            Debug.Log("Á¡¼öÈ¹µæ");
            PlayerInfo.score += 100;
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
