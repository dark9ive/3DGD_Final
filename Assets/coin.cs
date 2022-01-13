using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    GM GM_;

    string UpdateCoinString(int money){
        string tmp = "";
        for(int a = 0; a < 5; a++){
            tmp += (money%10).ToString() + " ";
            money /= 10;
        }
        tmp += (money%10).ToString();
        string returnval = "";
        for(int a = tmp.Length - 1; a >= 0; a--){
            returnval += tmp[a];
        }
        return returnval;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GM_ = GameObject.Find("GM").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = UpdateCoinString(GM_.money);
    }
}
