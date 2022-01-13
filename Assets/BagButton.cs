using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour
{
    public void OnClick(){
        if(transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
            Debug.Log("ID = 0!");
            return;
        }
        if(transform.parent.parent.parent.name == "MainUI"){
            Debug.Log("I'm in main!");
            return;
        }
        else{
            GameObject Input_slots = transform.parent.parent.parent.GetChild(transform.parent.parent.parent.childCount - 2).gameObject;
            for(int a = 0; a < Input_slots.transform.childCount; a++){
                if(Input_slots.transform.GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID() != 0){
                    Debug.Log("Skip child " + a.ToString());
                    continue;
                }
                else{
                    Input_slots.transform.GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID());
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
        
    }
}
