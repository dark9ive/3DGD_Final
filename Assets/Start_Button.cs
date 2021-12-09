using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Button : MonoBehaviour
{
    public GameObject loading_screen;
    public Slider slider;

    public void Click(){
        StartCoroutine(LoadScene1());
    }
    IEnumerator LoadScene1(){
        AsyncOperation op =  SceneManager.LoadSceneAsync (sceneName:"Stage1");

        loading_screen.SetActive(true);

        while(!op.isDone){
            //      When Unity finishes loading , op.progress
            //      returns 0.9, so divide a factor of 0.9f.
            slider.value = op.progress/0.9f;

            yield return null;
        }
    }
}
