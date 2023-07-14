using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private float yPos = 1f;

    private int currentIndex = 0;
    private GameObject[] enemys;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            count = 50;
        }

            int randomIdx =Random.Range(0, count);

        enemys = new GameObject[count];
        for(int i=0;i<count;i++)
        {
            if(SceneManager.GetActiveScene().name=="Stage1")
            {

            if(i%5==0)
            {
                enemys[i] = Instantiate(smallRingPrefab, poolPosition, Quaternion.identity, stage.transform);
            }
            else
            {

            enemys[i] = Instantiate(bigRingPrefab, poolPosition, Quaternion.identity,stage.transform);
            }
            }
            else

            {
                if(i%3==0)
                {

                    enemys[i] = Instantiate(smallRingPrefab, poolPosition, Quaternion.identity, stage.transform);

                }
                else
                {

                    enemys[i] = Instantiate(bigRingPrefab, poolPosition, Quaternion.identity, stage.transform);
                }

            }
        }
        timeBetSpawn = 0f;
        lastSpawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
     if(SceneManager.GetActiveScene().name=="Stage2")
        {
            yPos = -0.2f;
        }
       
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            if(SceneManager.GetActiveScene().name=="Stage1")
            {
            timeBetSpawn =Random.Range(2,6);
            if(timeBetSpawn%2==0)
                {
                    timeBetSpawn += 1;
                }

            }
            else if(SceneManager.GetActiveScene().name=="Stage2")
            {
                timeBetSpawn = Random.Range(2,4);
                if (timeBetSpawn % 2 == 0)
                {
                    timeBetSpawn += 1;
                }

            }
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
