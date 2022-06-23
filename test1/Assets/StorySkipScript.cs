using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySkipScript : MonoBehaviour
{
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Intro_scene");
        }
    } 
}
