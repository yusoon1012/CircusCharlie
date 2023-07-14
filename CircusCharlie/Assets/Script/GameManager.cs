using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance = null;

    //public static GameManager Instance{ get
    //    {
    //        return instance;
    //    }
    //}
    Player player;
    PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text bonusText;

    public AudioSource backgroundMusic;
    private float dieTimer = 0;
    private float dieRate = 3.5f;
    private int playerId = 0;

    private float stageTimer = 0f;
    private float stageRate = 5f;
    public int score = 0;
    private int playerHpCount = 3;
    //private void Awake()
    //{
    //    if (instance)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    // instance를 유일 오브젝트로 만든다
    //    instance = this;

    //    // Scene 이동 시 삭제 되지 않도록 처리
    //    DontDestroyOnLoad(this.gameObject);

    //}

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);
        playerController = FindAnyObjectByType<PlayerController>();
        backgroundMusic = GetComponent<AudioSource>();
        if(playerController.isPlayerDie==false)
        {
        backgroundMusic.Play();

        }

    }
    // Update is called once per frame
    void Update()
    {
        //if(SceneManager.GetActiveScene().name == ("Stage1")|| SceneManager.GetActiveScene().name == ("Stage2"))
        //{
        //if(playerController.isPlayerDie==true)
        //    {
        //    backgroundMusic.Stop();
        //}

        //}

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
                dieRate = 3.5f;
            }




            if (playerController.isGoal == true)
            {

                stageTimer += Time.deltaTime;

            }
            if (stageTimer >= stageRate)
            {
                stageTimer = 0;
                SceneManager.LoadScene("Stage2");
            }
        }
        else if (SceneManager.GetActiveScene().name == ("Stage2"))
        {
            
            if (playerController.isPlayerDie == true)
            {
                dieTimer += Time.deltaTime;
            }
            if (dieTimer >= dieRate)
            {
                dieTimer = 0;
                SceneManager.LoadScene("Stage2");
                dieRate = 3.5f;
            }
        }
        scoreText.text = string.Format("SCORE : {0}", PlayerInfo.score);
    }//update()

   


}
