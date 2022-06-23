using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePacmanVertically : MonoBehaviour
{
    public Vector2 speed = new Vector2((float)3.7,(float)3.7);
    private int smerx = 1;
    private SpriteRenderer mySpriteRenderer;
    void Start(){
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        Vector3 movement;
        if(inputx < 0) {
            smerx=-1;
            mySpriteRenderer.flipX = true;
        }
        else if (inputx > 0) {
            smerx=1;
            mySpriteRenderer.flipX = false;
            }
        movement = new Vector3(smerx*speed.x,0,0);
        movement *= Time.deltaTime;
        Vector3 v = transform.position; //Limiting player movement
        if (v.x < -5){
            v.x = -5;
        }
            
            
        else if (v.x > 5)
            v.x = 5;
        transform.position = v; 
        transform.Translate(movement);
    }
    void OnTriggerEnter2D(Collider2D col){
        Destroy(gameObject);
        SceneManager.LoadScene("Tetris scene");
        SpawnTetrisBlocks.timeruntillend = 60;

    }
}
