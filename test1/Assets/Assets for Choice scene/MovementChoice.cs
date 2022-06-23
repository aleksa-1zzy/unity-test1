using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovementChoice : MonoBehaviour
{
    public Vector2 speed = new Vector2(1,1);
    private int smerx=1;
    private int smery=0;
    private SpriteRenderer mySpriteRenderer;

    public float width = 200;
    public float height = 200;
    void Start(){
         mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical"); 

        Vector3 movement;
        if(this.transform.rotation.z == 0 || this.transform.rotation.z == 180 ){
        if(inputx < 0) {smerx=-1;smery=0;mySpriteRenderer.flipX = true;}
        else if (inputx > 0) {
            smerx=1;
            smery=0;
            mySpriteRenderer.flipX = false;
        }
        else if (inputy > 0) {
            smerx=0;smery=1;
            Vector3 rotation = new Vector3(0,90,0);
        }
        else if (inputy < 0) {
            smerx=0;
            smery=-1;
            // transform.rotation.z = 270;
            }
        }
        movement = new Vector3(smerx*speed.x,smery*speed.y,0);
        

        movement *= Time.deltaTime;

        Vector3 v = transform.position; //Limiting player movement
        if (v.x < -width)
            v.x = -width;
        else if (v.x > width)
            v.x = width;
        else if (v.y < -height)
            v.y = -height;
        else if (v.y > height)
            v.y = height;


        transform.position = v;

        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="GPU"){
            SceneManager.LoadScene("Worm Level");
        }
        else if(col.tag == "CPU"){
            SceneManager.LoadScene("Tetris scene");
        }
    }
}
