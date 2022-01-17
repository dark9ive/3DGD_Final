using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUI : MonoBehaviour
{
    public void BTNOnClick(){
        transform.parent.gameObject.SetActive(false);
        GameObject.Find("GM").GetComponent<GM>().Interacting_Other_UI = false;
        transform.parent.GetChild(transform.parent.childCount - 1).transform.SetParent(GameObject.Find("MainUI").transform);
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
