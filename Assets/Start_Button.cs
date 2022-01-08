using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using Models;
using Proyecto26;

public class Start_Button : MonoBehaviour
{
    public GameObject loading_screen;
    public Slider slider;

    public InputField userAccount, userPassword;
    public Text hint;

    void Start(){
        hint.text = ""; 
    }

    IEnumerator LoadScene1(){
        AsyncOperation op =  SceneManager.LoadSceneAsync (sceneName:"ChooseCloth");

        loading_screen.SetActive(true);

        while(!op.isDone){
            //      When Unity finishes loading , op.progress
            //      returns 0.9, so divide a factor of 0.9f.
            slider.value = op.progress/0.9f;

            yield return null;
        }
    }

    public void UserLogin(){
        string inputAccount = userAccount.text;
        string inputPassword = userPassword.text;

        CheckAccount(inputAccount, inputPassword);
    }
    void CheckAccount(string account, string password){ 
        bool isMatch = false;

        //發API的網址
        string url = "https://bkhole.app/islandxes?name=" + account;

        RestClient.Get(url).Then(res => {

            if(res.Text != "[]"){
                JSONObject j = new JSONObject(res.Text);
                string userPassword  =j.list[0].GetField("password").str;
                string userName = j.list[0].GetField("name").str;
                string userId = j.list[0].GetField("id").i.ToString();

                string type1 = j.list[0].GetField("type1").i.ToString();
                string type2 = j.list[0].GetField("type2").i.ToString();
                string type3 = j.list[0].GetField("type3").i.ToString();

                string task = j.list[0].GetField("t8task").str;

                //把username、外觀、任務狀態抓下來，換Scene時可讀
                PlayerPrefs.SetString("UserId", userId);
                PlayerPrefs.SetString("Outfit", type1 + '-' + type2 + '-' + type3);
                PlayerPrefs.SetString("Task", task);

                string UserId = PlayerPrefs.GetString("UserId");

                if(password == userPassword){
                    isMatch = true;
                }
            }

            if (isMatch){
                hint.text = "successful login";
                StartCoroutine(LoadScene1());
            }
            else{
                Debug.Log("Account or password is error");
                hint.text = "Account or password is error";
            }
        });
    }
    public void QuitGame(){
        Application.Quit();
    }
}
