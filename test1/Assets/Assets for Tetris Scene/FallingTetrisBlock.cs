using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTetrisBlock : MonoBehaviour
{
    public Vector2 fallingspeed = new Vector2(0,-4);

    void Update()
    {
        Vector3 movement = new Vector3(0,fallingspeed.y,0);
        movement *= Time.deltaTime;
        transform.Translate(movement);  
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "DestroyObjects")Destroy(gameObject);
    }
    
}
