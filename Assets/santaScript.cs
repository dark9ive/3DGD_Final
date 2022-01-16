using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class santaScript : MonoBehaviour
{
    float Next_motion = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(Next_motion <= Time.timeSinceLevelLoad){
            Next_motion += Random.Range(5, 10);
            wait();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("等待中");
            wait();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("成功過關");
            success();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("通關失敗");
            fail();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("正確訂單");
            correct();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("錯誤訂單");
            incorrect();
        }
        */
    }

    //等待訂單播的動畫
    public void wait()
    {
        gameObject.GetComponent<Animator>().SetTrigger("waiting");
    }

    //成功過關時播放的動畫
    public void success()
    {
        gameObject.GetComponent<Animator>().SetTrigger("success");
    }

    //過關失敗播的動畫
    public void fail()
    {
        gameObject.GetComponent<Animator>().SetTrigger("fail");
    }
    //繳交正確訂單播的動畫
    public void correct()
    {
        gameObject.GetComponent<Animator>().Play("correct");
    }
    //繳交錯誤訂單播放的動畫
    public void incorrect()
    {
        gameObject.GetComponent<Animator>().Play("incorrect");
    }
}
