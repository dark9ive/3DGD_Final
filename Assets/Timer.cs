using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int time_left_sec;

    string UpdateTimeString(int sec){
        string returnval = "";
        int min = sec/60;
        sec %= 60;
        returnval += (min/10).ToString() + " ";
        returnval += (min%10).ToString() + " : ";
        returnval += (sec/10).ToString() + " ";
        returnval += (sec%10).ToString();
        return returnval;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = UpdateTimeString(time_left_sec);
    }
}
