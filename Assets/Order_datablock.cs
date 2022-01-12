using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_datablock : MonoBehaviour
{
    private int [] part = {0, 0, 0};
    private float create_time;
    public void Generate_Rand_Order(){
        create_time = Time.timeSinceLevelLoad;
        part[0] = (Random.Range(1, 3) << 4) + (2 << 2) + Random.Range(0, 4); // 1 ~ 2, 0 ~ 3
        part[1] = (Random.Range(1, 3) << 4) + (3 << 2) + Random.Range(0, 4); // 1 ~ 2, 0 ~ 3
        part[2] = (3 << 4) + (Random.Range(1, 4) << 2) + Random.Range(0, 4); // 1 ~ 3, 0 ~ 3
        UpdatePic();
        return;
    }
    public float Exist_Time(){
        return Time.timeSinceLevelLoad - create_time;
    }

    public void copy(Order_datablock src){
        for(int a = 0; a < 3; a++){
            part[a] = src.part[a];
        }
        create_time = src.create_time;
        UpdatePic();
        return;
    }
    private void UpdatePic(){
        for(int a = 0; a < 3; a++){
            transform.GetChild(a).GetComponent<ItemSlotImg>().ChangePic(part[a]);
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