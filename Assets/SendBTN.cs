using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBTN : MonoBehaviour
{
    public void OnClick(){
        GameObject Orders = GameObject.Find("MainUI").transform.GetChild(1).gameObject;
        int order_count = GameObject.Find("GM").transform.GetComponent<GM>().order_count;
        bool success = false;
        for(int a = 0; a < order_count; a++){
            int count = 0;
            for(int b = 0; b < 3; b++){
                if(Orders.transform.GetChild(a).GetChild(b).GetComponent<ItemSlotImg>().getPicID() == transform.parent.GetChild(transform.parent.childCount - 4).GetChild(b).GetComponent<ItemSlotImg>().getPicID()){
                    count++;
                }
            }
            if(count == 3){
                GM GM_ = GameObject.Find("GM").GetComponent<GM>();
                for(int b = a + 1; b < order_count; b++){
                    GM_.orders[b-1].copy(GM_.orders[b]); 
                }
                GM_.order_count--;
                GM_.money += 1000;
                success = true;
                break;
            }
        }
        if(success){
            transform.parent.parent.GetComponent<santaScript>().correct();
        }
        else{
            transform.parent.parent.GetComponent<santaScript>().incorrect();
        }
        for(int a = 0; a < 3; a++){
            transform.parent.GetChild(transform.parent.childCount - 4).GetChild(a).GetComponent<ItemSlotImg>().ChangePic(0);
        }
        return;
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
