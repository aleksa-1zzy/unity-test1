using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeScript : MonoBehaviour
{
    private List<Transform> segments;
    private List<Vector3    > prevpositions;

    public Transform head;

    public Transform player;

    public Transform tail;

    Vector3 prevposition;
    private Transform lastsegment;

    private float size = 0.7f;
    public float waittime = 0.3f;
  //private float gapsize = 0.8f;
    private bool flag = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Follow());
        segments = new List<Transform>();
        segments.Add(this.transform);

    }

    // Update is called once per frame
    void Update()
    { 
        bool inputs = Input.GetKeyDown(KeyCode.G);
        if(inputs){
            flag = true;
        }
        if(AppleScript.EatenApple){
            Grow();
            AppleScript.EatenApple = false;
        }
    }
    IEnumerator Follow(){ 
        while(true){
        yield return new WaitForSeconds(waittime);
        prevpositions = new List<Vector3>();
        for (int i = 0; i < segments.Count; i++) {
            prevpositions.Add(segments[i].position); 
        }
        float angle = Mathf.Atan2((player.position.y-head.position.y),(player.position.x-head.position.x));
        if(angle<0)angle = 2*Mathf.PI+angle;
        if(angle<(Mathf.PI/4))head.position += new Vector3(size,0,0);
        else if (angle<(Mathf.PI*3/4))head.position += new Vector3(0,size,0); 
        else if (angle<(Mathf.PI*5/4))head.position += new Vector3(-size,0,0); 
        else if (angle<(Mathf.PI*7/4))head.position += new Vector3(0,-size,0); 
        else head.position += new Vector3(size,0,0);
        for (int i = 1; i < segments.Count; i++) {
            segments[i].position = prevpositions[i-1]; 
        }
        if (flag) {
            flag = false;
            Grow();
        }
    }
    }
    public void Grow(){
        Transform newsegment = Instantiate(this.tail);
        newsegment.position = prevpositions[prevpositions.Count - 1];
        segments.Add(newsegment);
     }
      void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="SnakeTail"){
           Debug.Log("MY TAIL");
           GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("SnakeTail");   
                foreach (GameObject SnakePart in taggedObjects) {
	                Destroy(SnakePart);
                }
            Destroy(this.gameObject);
            SceneManager.LoadScene("Choice_Scene");
        }
        
    }
}
