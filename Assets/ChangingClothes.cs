using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using Models;
using Proyecto26;

public class ChangingClothes : MonoBehaviour
{
    public GameObject loading_screen;
    public Slider slider;

    //Clothing state
    //0: nothing
    //up/mid: 1:Reindeer 2:Angel 3:Santa
    //shoes: 1:Rocket 2:Wings 3:Ring
    public int hatId, bodyId ,shoeId;

    public GameObject hat1, hat2, hat3;
    public GameObject body0, body1, body2, body3;
    public GameObject leftShoe1, rightShoe1, leftShoe2, rightShoe2, leftShoe3, rightShoe3;

    public GameObject hatActive1, hatActive2, hatActive3;
    public GameObject bodyActive1, bodyActive2, bodyActive3;
    public GameObject shoeActive1, shoeActive2, shoeActive3;
    public GameObject closetActive;

    public Text pocketInfo, speedInfo;

    string UserId;

    void Start()
    {
        GetOutfit();
        //GameObject.Find("MenuMusicManager").GetComponent<KeepPlayingBetweenScenes>().PlayMusic();
        //GameObject.Find("GamingMusicManager").GetComponent<KeepPlayingBetweenScenes>().StopMusic();
    }

    void GetOutfit(){
        UserId = PlayerPrefs.GetString("UserId");
        if(PlayerPrefs.HasKey("Outfit")){
            string outfit = PlayerPrefs.GetString("Outfit");
            int _hatId = int.Parse(outfit.Split('-')[0]);
            int _bodyId = int.Parse(outfit.Split('-')[1]);
            int _shoeId = int.Parse(outfit.Split('-')[2]);
            ChangeHat(_hatId);
            ChangeBody(_bodyId);
            ChangeShoe(_shoeId);
        }
        if(PlayerPrefs.HasKey("Task")){
            string task = PlayerPrefs.GetString("Task");
            Debug.Log(task);
        }
    }
    
    public void DefaultOutfit(){
        ChangeHat(0);
        ChangeBody(0);
        ChangeShoe(0);
    }

    public void ChooseClothes(string name){
        string _type = name.Split('-')[0];
        int _id = int.Parse(name.Split('-')[1]);
        ChangeSomething(_type, _id);
    }

    void ChangeSomething(string type, int id){
        switch(type){
            case "Hat":
                ChangeHat(id);
                break;
            case "Body":
                ChangeBody(id);
                break;
            case "Shoe":
                ChangeShoe(id);
                break;
        }
    }
    
    void ChangeHat(int id){
        hatId = id;
        if(id == 0){
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(false);

            hatActive1.SetActive(false);
            hatActive2.SetActive(false);
            hatActive3.SetActive(false);
        }
        if(id == 1){
            hat1.SetActive(true);
            hat2.SetActive(false);
            hat3.SetActive(false);

            hatActive1.SetActive(true);
            hatActive2.SetActive(false);
            hatActive3.SetActive(false);
        }
        if(id == 2){
            hat1.SetActive(false);
            hat2.SetActive(true);
            hat3.SetActive(false);

            hatActive1.SetActive(false);
            hatActive2.SetActive(true);
            hatActive3.SetActive(false);
        }
        if(id == 3){
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(true);

            hatActive1.SetActive(false);
            hatActive2.SetActive(false);
            hatActive3.SetActive(true);
        }
    }
    void ChangeBody(int id){
        bodyId = id;
        if(id == 0){
            body0.SetActive(true);
            body1.SetActive(false);
            body2.SetActive(false);
            body3.SetActive(false);

            bodyActive1.SetActive(false);
            bodyActive2.SetActive(false);
            bodyActive3.SetActive(false);

            pocketInfo.text = "4";
        }
        if(id == 1){
            body0.SetActive(false);
            body1.SetActive(true);
            body2.SetActive(false);
            body3.SetActive(false);

            bodyActive1.SetActive(true);
            bodyActive2.SetActive(false);
            bodyActive3.SetActive(false);

            pocketInfo.text = "4";
        }
        if(id == 2){
            body0.SetActive(false);
            body1.SetActive(false);
            body2.SetActive(true);
            body3.SetActive(false);

            bodyActive1.SetActive(false);
            bodyActive2.SetActive(true);
            bodyActive3.SetActive(false);

            pocketInfo.text = "6";
        }
        if(id == 3){
            body0.SetActive(false);
            body1.SetActive(false);
            body2.SetActive(false);
            body3.SetActive(true);

            bodyActive1.SetActive(false);
            bodyActive2.SetActive(false);
            bodyActive3.SetActive(true);

            pocketInfo.text = "5";
        }
    }
    
    void ChangeShoe(int id){
        shoeId = id;
        if(id == 0){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);

            shoeActive1.SetActive(false);
            shoeActive2.SetActive(false);
            shoeActive3.SetActive(false);

            speedInfo.text = "1.0";
        }
        if(id == 1){
            leftShoe1.SetActive(true);
            rightShoe1.SetActive(true);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);

            shoeActive1.SetActive(true);
            shoeActive2.SetActive(false);
            shoeActive3.SetActive(false);

            speedInfo.text = "1.5";
        }
        if(id == 2){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(true);
            rightShoe2.SetActive(true);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);

            shoeActive1.SetActive(false);
            shoeActive2.SetActive(true);
            shoeActive3.SetActive(false);

            speedInfo.text = "1.3";
        }
        if(id == 3){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(true);
            rightShoe3.SetActive(true);

            shoeActive1.SetActive(false);
            shoeActive2.SetActive(false);
            shoeActive3.SetActive(true);

            speedInfo.text = "1";
        }
    }
    
    public void StartGame(){
        closetActive.SetActive(false);
        PlayerPrefs.SetString("Outfit", hatId.ToString() + '-' + bodyId.ToString() + '-' +  shoeId.ToString());

        //把裝備資料推回去
        string url = "https://bkhole.app/islandxes/" + UserId;
        
        RestClient.Put(url, "{\"type1\":" + hatId + "}");
        RestClient.Put(url, "{\"type2\":" + bodyId + "}");
        RestClient.Put(url, "{\"type3\":" + shoeId + "}");

        StartCoroutine(LoadScene("Demo 01"));
    }
    public void QuitGame(){
        StartCoroutine(LoadScene("Main_Menu"));
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
