using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;


public class GameManager : MonoBehaviour
{

    Player player;
    PlayerController playerController;

    public AudioSource backgroundMusic;
    private float dieTimer = 0;
    private float dieRate = 2f;
    private int playerId = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        playerController = FindAnyObjectByType<PlayerController>();
        backgroundMusic = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
       

        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Stage1");
            }

        }
        if (SceneManager.GetActiveScene().name == ("Stage1"))
        {

            if (playerController.isPlayerDie == true)
            {
                dieTimer += Time.deltaTime;
            }
            if (dieTimer >= dieRate)
            {
                dieTimer = 0;
                SceneManager.LoadScene("Stage1");
                dieRate = 2f;
            }
            if(playerController.isGoal==true)
            {
                SceneManager.LoadScene("Stage2");

            }
        }
        if (SceneManager.GetActiveScene().name == ("Stage2"))
        {

        }





    }
}
