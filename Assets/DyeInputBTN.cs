using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyeInputBTN : MonoBehaviour
{

    public void OnClick(){
        if(transform.GetChild(0).GetComponent<ItemSlotImg>().getPicID() == 0){
            return;
        }
        //  TODO: Search Bag for blank.
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
