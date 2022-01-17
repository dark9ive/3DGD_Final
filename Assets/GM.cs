using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Models;
using Proyecto26;
using Random = UnityEngine.Random;


public class GM : MonoBehaviour
{
    public double interact_distance_thresh;
    public GameObject Player;
    public Timer Timer_;
    public int Level_time = 300;
    float start_time;
    public int money = 0;
    public bool Interacting_Other_UI = false;
    public Sprite[] spriteList;
    
    public GameObject loading_screen;
    public Slider slider;
    public GameObject PauseMenuUI, HintUI;
    public GameObject FailUI, SuccessUI;
    public AudioSource Button, ClockTicking, TimesUp;

    public int order_count = 0;
    private float next_order = 0.0f;
    public Order_datablock [] orders;

    public string UserId;
    public int task1, task2 ,task3;
    
    private bool isPause = false;
    private bool isCountingDown = false;
    private bool isTimesUp = false;



    double Distance(GameObject a, GameObject b){
        double returnval = 0;
        returnval += Math.Pow((a.transform.position.x - b.transform.position.x), 2);
        returnval += Math.Pow((a.transform.position.y - b.transform.position.y), 2);
        returnval += Math.Pow((a.transform.position.z - b.transform.position.z), 2);
        returnval = Math.Pow(returnval, 0.5);
        return returnval;
    }

    void End(){
        Debug.Log("Game Over!");
        var objects = GameObject.FindGameObjectsWithTag("UI");
        foreach (var obj in objects) {
            obj.SetActive(false);
        }
        Time.timeScale = 0;
        //  Hide bag.
        GameObject.Find("MainUI").transform.GetChild(GameObject.Find("MainUI").transform.childCount - 1).gameObject.SetActive(false);
        //Check point ,if success ###
        if(money >= 3000){
            SuccessUI.SetActive(true);
        }
        else{
            FailUI.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetState();
        Time.timeScale = 1;
        GameObject.Find("MenuMusicManager").GetComponent<KeepPlayingBetweenScenes>().StopMusic();
        GameObject.Find("GamingMusicManager").GetComponent<KeepPlayingBetweenScenes>().PlayMusic();
    }

    void GetState(){
        UserId = PlayerPrefs.GetString("UserId");
        string task = PlayerPrefs.GetString("Task");
        task1 = int.Parse(task.Split('-')[1]);
        task2 = int.Parse(task.Split('-')[2]);
        task3 = int.Parse(task.Split('-')[3]);
    }

    // Update is called once per frame
    void Update()
    {
        //  #################################################
        //      Determine which object to interact(Key F)
        //  #################################################
        var objects = GameObject.FindGameObjectsWithTag("interact_item");
        //var objectCount = objects.Length;
        var ShowWordObj = Player;
        double Min_distance = System.Double.MaxValue;
        foreach (var obj in objects) {
            obj.transform.GetChild(0).gameObject.SetActive(false);
            double tmp = Distance(obj, Player);
            if (tmp < Min_distance && tmp <= interact_distance_thresh){
                ShowWordObj = obj;
                Min_distance = tmp;
            }
        }
        //Debug.Log(Min_distance.ToString());
        if(ShowWordObj != Player){
            ShowWordObj.transform.GetChild(0).gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.F) && !Interacting_Other_UI){
                //  Show Interact Item UI.
                ShowWordObj.transform.GetChild(1).gameObject.SetActive(true);
                //  Send Bag UI to Interact Item UI.
                GameObject.Find("MainUI").transform.GetChild(GameObject.Find("MainUI").transform.childCount - 1).transform.SetParent(ShowWordObj.transform.GetChild(1));
                //  Lock Interact.
                Interacting_Other_UI = true;
                //  Play Sound.
                Button.Play();
            }
        }
        //  #################################################
        //                     End Section
        //  #################################################
        //  #################################################
        //                   Count Time Left.
        //  #################################################
        Timer_.time_left_sec = Mathf.FloorToInt(Level_time - (Time.timeSinceLevelLoad - start_time));
        if(Timer_.time_left_sec == 10){
            if(!isCountingDown){    
                ClockTicking.Play();
                isCountingDown = true;
            }
        }
        if(Timer_.time_left_sec <= 0){
            Timer_.time_left_sec = 0;
            if(!isTimesUp){
                TimesUp.Play();
                isTimesUp = true;
                End();
            }
            
        }
        //  #################################################
        //                     End Section
        //  #################################################
        //  #################################################
        //                     If paused...
        //  #################################################
        if(isPause == true && Input.GetKeyDown(KeyCode.Escape)){
            Button.Play();
            ResumeGame();
        }
        //  #################################################
        //                     End Section
        //  #################################################

    }
    void FixedUpdate(){
        //  #################################################
        //                    Random Order
        //  #################################################
        if(order_count < 6 && Time.timeSinceLevelLoad >= next_order){
            orders[order_count].Generate_Rand_Order();
            order_count++;
            next_order = Time.timeSinceLevelLoad + Random.Range(20.0f, 25.0f);
        }
    }
    public void PauseGame(){
        isPause = true;
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        if (isCountingDown == true){
            ClockTicking.Pause();
        }
    }
    public void ResumeGame(){
        isPause = false;
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        HintUI.SetActive(false);
        GameObject.Find("MainUI").transform.GetChild(GameObject.Find("MainUI").transform.childCount - 1).gameObject.SetActive(true);
        if (isCountingDown == true){
            ClockTicking.Play();
        }
    }
    public void RestartGame(){
        StartCoroutine(LoadScene("Demo 01"));
    }
    public void QuitGame(){
        StartCoroutine(LoadScene("ChooseCloth"));
    }
    public void NextStage(){
        //To Next stage
        //StartCoroutine(LoadScene("ChooseCloth"));
    }
    public void HintInGame(){
        isPause = true;
        Time.timeScale = 0;
        HintUI.SetActive(true);
        GameObject.Find("MainUI").transform.GetChild(GameObject.Find("MainUI").transform.childCount - 1).gameObject.SetActive(false);
        if (isCountingDown == true){
            ClockTicking.Pause();
        }
    }
    IEnumerator LoadScene(string SceneName){
        AsyncOperation op =  SceneManager.LoadSceneAsync (sceneName: SceneName);

        loading_screen.SetActive(true);

        while(!op.isDone){

            slider.value = op.progress/0.9f;

            yield return null;
        }
    }
}
