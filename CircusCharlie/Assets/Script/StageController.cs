using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class StageController : MonoBehaviour
{
    private float speed = 3f;
    Player player;
    private int playerId = 0;
    PlayerController playerCon;

    
    private int dir;
    private int playerDir;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        playerCon = GameObject.FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerCon.isPlayerDie == true)
        {
            return;
        }
        if(playerCon.isGoal==true)
        {

            return;
        }
        if (playerCon.isJump == false)
        {
            
           
            if (player.GetButton("Player Left")&&transform.position.x>-45)
            {
                if (transform.position.x > 0)
                {
                    return;
                }
                
                dir = -1;
                playerDir = -1;
                transform.Translate(Vector3.right * speed * Time.deltaTime);

            }
            else if (player.GetButton("Player Right") && transform.position.x > -45)
            {
               
                dir = 1;
                playerDir = 1;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                dir = 0;
            }


        }
        if (playerCon.isJump == true && transform.position.x > -45&&transform.position.x<0 )
        {
            transform.Translate(Vector3.left * dir * speed * Time.deltaTime);
        }

            //if (transform.position.x > 0 && dir == -1)
            //{
            //    playerCon.transform.Translate(Vector3.left* speed * Time.deltaTime);

               
            //}
           if (player.GetButton("Player Right")&&transform.position.x < -45&&playerCon.isJump==false)
            {
                playerCon.transform.Translate(Vector3.right* speed * Time.deltaTime);
                 dir = -1;
            playerDir = 1;


            }
           else if(playerCon.isJump == true && transform.position.x < -45&&dir==-1)
        {
            playerCon.transform.Translate(Vector3.right* speed * Time.deltaTime);

        }
            else if(player.GetButton("Player Left")&&transform.position.x < -45 && playerCon.isJump == false)
            {
                playerCon.transform.Translate(Vector3.left * speed * Time.deltaTime);
            dir = 1;
            playerDir = -1;
            }
        else if (transform.position.x < -45 && playerCon.isJump == true&&dir==1)
        {
            playerCon.transform.Translate(Vector3.right *playerDir* speed * Time.deltaTime);
           
        }






        //if (player.GetButton("Player Right")&&)
        //{
        //    playerCon.transform.Translate(Vector3.right* speed * Time.deltaTime);

        //}
        //else if(player.GetButton("Player Left")&&transform.position.x < -45)
        //{
        //    playerCon.transform.Translate(Vector3.left * speed * Time.deltaTime);

        //}

    }




}

