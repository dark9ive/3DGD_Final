using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBTN : MonoBehaviour
{
    public AudioSource DyeBottomSound;

    public void OnClick(){
        if(transform.parent.GetChild(transform.parent.childCount - 4).GetChild(0).GetComponent<ItemSlotImg>().getPicID() != 0){
            Debug.Log("Not Empty!");
            return;
        }
        for(int a = 0; a < 3; a++){
            if(transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
                Debug.Log("Not Full!");
                return;
            }
        }
        for(int a = 0; a < 3; a++){
            int myID = transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().getPicID();
            transform.parent.GetChild(transform.parent.childCount - 4).GetChild(a).GetComponent<ItemSlotImg>().ChangePic(myID);
            transform.parent.GetChild(transform.parent.childCount - 2).GetChild(a).GetChild(0).GetComponent<ItemSlotImg>().ChangePic(0);
        }
        DyeBottomSound.Play();
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
