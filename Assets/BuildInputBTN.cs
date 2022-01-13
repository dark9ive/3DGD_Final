using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInputBTN : MonoBehaviour
{
    public void OnClick(){
        int myID = transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID();
        if(myID == 0){
            Debug.Log("ID = 0!");
            return;
        }
        else{
            GameObject Bag_slots = transform.parent.parent.GetChild(transform.parent.parent.childCount - 1).gameObject;
            for(int a = 3; a < Bag_slots.transform.childCount; a++){
                if(Bag_slots.transform.GetChild(a).GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().getPicID() != 0){
                    continue;
                }
                else{
                    Bag_slots.transform.GetChild(a).GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                    transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int myID = transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID();
        if(myID == 0){
            return;
        }
        switch(transform.GetSiblingIndex()){
            case 0:
                if(((myID>>2) & 0xF) == 7 || ((myID>>2) & 0xF) == 11){  //  Type Body.
                    if(transform.parent.GetChild(1).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(1).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                else if((myID>>4) == 3 ){  //  Type Part.
                    if(transform.parent.GetChild(2).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(2).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                break;
            case 1:
                if(((myID>>2) & 0xF) == 6 || ((myID>>2) & 0xF) == 10){  //  Type Head.
                    if(transform.parent.GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                else if((myID>>4) == 3 ){  //  Type Part.
                    if(transform.parent.GetChild(2).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(2).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                break;
            case 2:
                if(((myID>>2) & 0xF) == 6 || ((myID>>2) & 0xF) == 10){  //  Type Head.
                    if(transform.parent.GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(0).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                else if(((myID>>2) & 0xF) == 7 || ((myID>>2) & 0xF) == 11){  //  Type Body.
                    if(transform.parent.GetChild(1).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                        transform.parent.GetChild(1).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID);
                        transform.GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                    }
                    else{
                        OnClick();
                    }
                }
                break;
            default:
                Debug.Log("Index Error!");
                break;
        }
    }
}