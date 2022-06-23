using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public static  bool EatenApple = false; //Checks if apple is eaten
    // Start is called before the first frame update
    private bool destroyed = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyed){
        
         destroyed = false;
     }   
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Snake"){
           EatenApple = true;
           Destroy(this.gameObject);
           
        }
         
    }
    void OnDestroy() {
        if(destroyed){
    AppleSpawner.NumberOfSpawned--;
            destroyed = false;
        }
     
    }
}
