using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBag : MonoBehaviour
{
    public int BagSize = 0;
    public void SetBag(int size){
        BagSize = size;
        Instantiate(GameObject.Find("Slot_Top"), transform, true);
        transform.GetChild(3).localPosition = new Vector3(0f, 117.6f*((float)BagSize/2.0f - 1f) + 130.2f / 2.0f, 0f);
        for(int a = 1; a < BagSize-1; a++){
            Instantiate(GameObject.Find("Slot_Mid"), transform, true);
            transform.GetChild(3+a).localPosition = new Vector3(0, 117.6f*((float)BagSize/2.0f - 0.5f - (float)a), 0);
            //130.2 117.6 133
        }
        Instantiate(GameObject.Find("Slot_Bottom"), transform, true);
        transform.GetChild(3+BagSize-1).localPosition = new Vector3(0, 117.6f*(-(float)BagSize/2.0f + 1f) - 133f / 2, 0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){

    }
}
