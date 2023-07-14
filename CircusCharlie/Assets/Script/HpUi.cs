using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUi : MonoBehaviour
{
    public GameObject[] playerHpImage;
   

    private int hpMax = 3;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp = PlayerInfo.playerHp;

        if(hp<1)
        {
            Destroy(playerHpImage[0].gameObject);
            Destroy(playerHpImage[1].gameObject);
            Destroy(playerHpImage[2].gameObject);
        }
        else if(hp<2)
        {
            Destroy(playerHpImage[1].gameObject);
            Destroy(playerHpImage[2].gameObject);

        }
        else if (hp < 3)
        {
            Destroy(playerHpImage[2].gameObject);

        }
    }
}
