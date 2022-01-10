using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public double interact_distance_thresh;
    public GameObject Player;
    public Timer Timer_;
    public int Level_time = 300;
    float start_time;
    public bool Interacting_Other_UI = false;
    public Sprite[] spriteList;

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
    }
    // Start is called before the first frame update
    void Start()
    {

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
                GameObject.Find("MainUI").transform.GetChild(3).transform.SetParent(ShowWordObj.transform.GetChild(1));
                //  Lock Interact.
                Interacting_Other_UI = true;
            }
        }
        //  #################################################
        //                  End Section
        //  #################################################
        Timer_.time_left_sec = Mathf.FloorToInt(Level_time - (Time.time - start_time));
        if(Timer_.time_left_sec <= -1){
            End();
        }
    }
}
