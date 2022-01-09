using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotImg : MonoBehaviour
{
    int picID;
    //public Sprite Default;
    public int getPicID(){
        return picID;
    }
    void ChangePic(int NewID){
        picID = NewID;
        GetComponent<Image>().sprite = GameObject.Find("GM").GetComponent<GM>().spriteList[picID];
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        picID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
