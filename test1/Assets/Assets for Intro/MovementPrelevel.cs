using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class MovementPrelevel : MonoBehaviour
{   
    public Vector2 speed = new Vector2(1,0);

    void Update()
    {
        Vector3 movement = new Vector3(speed.x,0,0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
           SceneManager.LoadScene("Choice_Scene");
        
    }
    
}
