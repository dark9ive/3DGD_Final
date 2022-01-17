using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
        if(Input.GetKey(KeyCode.F) && !transform.parent.GetChild(1).gameObject.activeSelf){
            Debug.Log("Meow");
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
    }
}
