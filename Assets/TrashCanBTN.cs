using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanBTN : MonoBehaviour
{

    public void OnClick(){
        int myID = transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID();
        if(myID == 0){
            Debug.Log("ID = 0!");
            return;
        }
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}