using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour
{
    GameObject gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerInfo.score += 1000;
            Destroy(gold);

        }
    }


}
