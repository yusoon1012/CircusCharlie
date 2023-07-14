using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayer : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRigid;
    EndManager endManager;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playerRigid=GetComponent<Rigidbody2D>();
        endManager=GameObject.FindAnyObjectByType<EndManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Dead"))
        {
            endManager.OnDieCheck();
            Destroy(player);
            Destroy(playerRigid);
        }
    }
}
