using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTetrisBlocks : MonoBehaviour
{
    public GameObject[] prefabs;
    
    public float waitingfornextspawn = 10;
    public float thecountdown = 10;
    public int maxspawnnumber = 2;
    public static float timeruntillend = 60;
    Collider2D m_collider;
    Vector3 m_size;
    
    void Start(){
        m_collider = GetComponent<Collider2D>();
        m_size = m_collider.bounds.size;
    }
    void Update()
    {   
        thecountdown -= Time.deltaTime;
        timeruntillend -= Time.deltaTime;
        if(timeruntillend>40 && timeruntillend<60){waitingfornextspawn=1.1f;}
        else if(timeruntillend>20 && timeruntillend<40){waitingfornextspawn=0.8f;}
        else if(timeruntillend<20 && timeruntillend>0){waitingfornextspawn=0.7f;}
        if(timeruntillend<=0){
            SceneManager.LoadScene("Choice_Scene");
        }
        if(thecountdown <= 0){
            for(int i=0;i<maxspawnnumber;i++)Spawn();
            thecountdown = waitingfornextspawn;
        }
    }
    void Spawn(){
         Vector3 pos = new Vector3(Random.Range((float)-4.7,(float)4.8),Random.Range((float)4.0,(float)6),0);  
         GameObject spawnprefab = prefabs[Random.Range(0,prefabs.Length)];
         Instantiate (spawnprefab,pos,Quaternion.identity);
    }
}
