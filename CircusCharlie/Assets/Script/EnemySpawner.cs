using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bigRingPrefab;
    public GameObject smallRingPrefab;
    public GameObject stage;
    public int count = 20;
    private float timeBetSpawn;
    private float lastSpawnTime;


    private Vector2 poolPosition = new Vector2(0, -25f);
    private int xPos = 10;
    private int yPos = 1;

    private int currentIndex = 0;
    private GameObject[] enemys;

    // Start is called before the first frame update
    void Start()
    {
        enemys = new GameObject[count];
        for(int i=0;i<count;i++)
        {
            enemys[i] = Instantiate(bigRingPrefab, poolPosition, Quaternion.identity,stage.transform);
        }
        timeBetSpawn = 0f;
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn =Random.Range(2,6);
            enemys[currentIndex].SetActive(false);
            enemys[currentIndex].SetActive(true);
            enemys[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex += 1;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
       


    }

    public void DestroyEnemy(GameObject enemy)
    {
        int index = System.Array.IndexOf(enemys, enemy);
        if (index != -1)
        {
            enemys[index].SetActive(false);
        }
    }
}
