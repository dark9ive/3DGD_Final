using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemSlotImg : MonoBehaviour
{
    public int picID;
    //public Sprite Default;
    public int getPicID(){
        return picID;
    }
    public void ChangePic(int NewID){
        picID = NewID;
        GameObject GM = GameObject.Find("GM");
        GetComponent<Image>().sprite = GM.GetComponent<GM>().spriteList[picID];
        try{
            GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Image>().sprite.textureRect.width, GetComponent<Image>().sprite.textureRect.height);
        }
        catch(UnassignedReferenceException e){
            GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
        catch(NullReferenceException e){
            GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        //picID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
