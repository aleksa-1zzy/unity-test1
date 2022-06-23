using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountdownTextScript : MonoBehaviour
{
    public Text mytext;
    private float time;
    void Start(){
    }
    // Start is called before the first frame update
    void Update()
    {
        time = SpawnTetrisBlocks.timeruntillend;
        mytext.text = time.ToString();

    }
}
