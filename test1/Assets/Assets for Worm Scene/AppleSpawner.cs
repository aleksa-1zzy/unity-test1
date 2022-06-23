using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public AppleScript apple;
    public int waitseconds = 3;
    public int MaxSpawnNumber = 20;
    public static int NumberOfSpawned = 0;  
                
    void Start()
    {
       StartCoroutine(Spawner());
    }
    void Update(){}
    IEnumerator Spawner(){
            while(NumberOfSpawned<MaxSpawnNumber){
            NumberOfSpawned++;
            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            if(spawnX>0)spawnX--;
            else spawnX++;
            if(spawnY>0)spawnY--;
            else spawnY++;   
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(apple, spawnPosition, Quaternion.identity);
            Debug.Log(NumberOfSpawned);

             yield return new WaitForSeconds(waitseconds); 
        }
    }
} 
