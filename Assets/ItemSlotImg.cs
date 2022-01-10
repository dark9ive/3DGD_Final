using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            GetComponent<RectTransform>().sizeDelta = new Vector2(GM.GetComponent<GM>().spriteList[picID].textureRect.width, GM.GetComponent<GM>().spriteList[picID].textureRect.height);
        }
        catch(UnassignedReferenceException e){
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
