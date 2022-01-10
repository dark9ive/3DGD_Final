using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DyeStartBTN : MonoBehaviour
{
    public bool [] working = new bool[3];
    float [] start_time = new float[3];
    public float dye_time;
    public int color_code;
    public void OnClick(){
        for(int a = 0; a < 3; a++){
            int inputID = transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID();
            int outputID = transform.parent.GetChild(transform.parent.childCount - 4).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID();
            if((working[a] == false) && ((inputID & 3) == 0) && (inputID != 0) && (outputID == 0)){
                working[a] = true;
                start_time[a] = Time.time;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int a = 0; a < 3; a++){
            working[a] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int a = 0; a < 3; a++){
            if(working[a] == true){
                float tmp = (Time.time - start_time[a]) / dye_time;
                if(tmp < 1){
                    transform.parent.GetChild(transform.parent.childCount - 3).GetChild(a).GetComponent<Slider>().value = tmp;
                    continue;
                }
                else{
                    working[a] = false;
                    int myID = transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID();
                    transform.parent.GetChild(transform.parent.childCount - 4).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(myID + color_code);
                    transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
                }
            }
            transform.parent.GetChild(transform.parent.childCount - 3).GetChild(a).GetComponent<Slider>().value = 0;
        }
    }
}
