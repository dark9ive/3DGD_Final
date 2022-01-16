using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;

public class CheckAndSendPoint : MonoBehaviour
{    

    void Start()
    {
        GameObject QuestInfo = this.gameObject.transform.GetChild(8).gameObject.gameObject.transform.GetChild(3).gameObject;
        GameObject Quest1 = QuestInfo.transform.GetChild(0).gameObject;
        GameObject Quest2 = QuestInfo.transform.GetChild(1).gameObject;
        GameObject Quest3 = QuestInfo.transform.GetChild(2).gameObject;
        

        
        string UserId = GameObject.Find("GM").GetComponent<GM>().UserId;
        int task1 = GameObject.Find("GM").GetComponent<GM>().task1;
        int task2 = GameObject.Find("GM").GetComponent<GM>().task2;
        int task3 = GameObject.Find("GM").GetComponent<GM>().task3;
        
        int money = GameObject.Find("GM").GetComponent<GM>().money;


        if(money >= 0){
            if(money >= 3000){
                if(task1 != 1){
                    task1 = 1;
                }
                if(money >= 5000){
                    GameObject Star2 = this.gameObject.transform.GetChild(9).gameObject;
                    Star2.SetActive(true);
                    if(task2 != 1){
                        task2 = 1;
                    }
                }
                if(money >= 8000){
                    GameObject Star3 = this.gameObject.transform.GetChild(10).gameObject;
                    Star3.SetActive(true);
                    if(task3 != 1){
                        task3 = 1;
                    }
                }
            }
            if(task1 == 1){
                Quest1.SetActive(true);
            }
            if(task2 == 1){
                Quest2.SetActive(true);
            }
            if(task3 == 1){
                Quest3.SetActive(true);
            }
        }
        string url = "https://bkhole.app/islandxes/" + UserId;
        RestClient.Put(url, "{\"t8task\":\"1-" + task1 + "-" + task2 + "-" + task3 + "\"}");
        RestClient.Put(url, "{\"t8score\":\"" + money + "\"}");

        PlayerPrefs.SetString("Task", "1-" + task1 + "-" + task2 + "-" + task3);
    }
}
