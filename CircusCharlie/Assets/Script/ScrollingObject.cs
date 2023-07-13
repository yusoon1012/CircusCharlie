using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public GameObject fireRing;
    Rigidbody2D fireRigid;
    public float speed = 5f;
    PlayerController playercon;
    EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        playercon = GameObject.FindAnyObjectByType<PlayerController>();
        enemySpawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        fireRing = gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playercon.isGoal==true)
        {
            return;
        }
        if (playercon.isPlayerDie == false )
        {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("RingClear"))
        {
            Destroy(fireRing);
            enemySpawner.DestroyEnemy(fireRing);
        }
    }
}
