using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public double interact_distance_thresh = 10.0;
    public GameObject Player;

    double Distance(GameObject a, GameObject b){
        double returnval = 0;
        returnval += Math.Pow((a.transform.position.x - b.transform.position.x), 2);
        returnval += Math.Pow((a.transform.position.y - b.transform.position.y), 2);
        returnval += Math.Pow((a.transform.position.z - b.transform.position.z), 2);
        returnval = Math.Pow(returnval, 0.5);
        return returnval;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if(ShowWordObj != Player){
            ShowWordObj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
