using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public bool isPlayerDie = false;
    public AudioSource endCredit;
    public AudioClip deathClip;
    private float endGameTimer = 0f;
    private float endGameRate = 5f;
    private int deathCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        endCredit.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDie==true)
        {
           
            endCredit.clip = deathClip;
            if(endCredit.isPlaying == false )
            {
                if(deathCount<1)
                {
            endCredit.Play();
                    deathCount += 1 ;
                }
            }
            endGameTimer += Time.deltaTime;
        }

        if(endGameTimer > endGameRate)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void OnDieCheck()
    { 
        isPlayerDie = true;
    }
}
