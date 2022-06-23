using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
