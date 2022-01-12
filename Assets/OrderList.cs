using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderList : MonoBehaviour
{
    GM GM_;
    public float MAX_ORDER_TIME;
    Color color_by_percent(float percent){
        int r = percent < 0.5f ? 255 : Mathf.FloorToInt(255-(percent*2-100)*255/100);
        int g = percent > 0.5f ? 255 : Mathf.FloorToInt((percent*2)*255/100);
        return new Color(r, g, 0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GM_ = GameObject.Find("GM").GetComponent<GM>();
        for(int a = 0; a < GM_.order_count; a++){
            if(GM_.orders[a].Exist_Time() >= MAX_ORDER_TIME){
                for(int b = a + 1; b < GM_.order_count; b++){
                    GM_.orders[b-1].copy(GM_.orders[b]); 
                }
                GM_.order_count--;
                a--;
            }
            else{
                transform.GetChild(a).gameObject.SetActive(true);
                transform.GetChild(a).GetChild(3).GetComponent<Slider>().value = 1.0f - transform.GetChild(a).GetComponent<Order_datablock>().Exist_Time() / MAX_ORDER_TIME;
                transform.GetChild(a).GetChild(3).GetChild(1).GetChild(0).GetComponent<Image>().color = color_by_percent(transform.GetChild(a).GetChild(3).GetComponent<Slider>().value);
            }
        }
        for(int a = GM_.order_count; a < 6; a++){
            transform.GetChild(a).gameObject.SetActive(false);
        }
    }
}
