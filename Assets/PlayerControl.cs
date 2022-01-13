using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode UP = KeyCode.W;
    public KeyCode LEFT = KeyCode.A;
    public KeyCode DOWN = KeyCode.S;
    public KeyCode RIGHT = KeyCode.D;
    public float Speed;
    
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        Vector3 MoveVec = new Vector3(0f, 0f, 0f);
        if(Input.GetKey(UP)){
            MoveVec += new Vector3(0f, 0f, 1.0f);
        }
        if(Input.GetKey(LEFT)){
            MoveVec += new Vector3(-1.0f, 0f, 0f);
        }
        if(Input.GetKey(DOWN)){
            MoveVec += new Vector3(0f, 0f, -1.0f);
        }
        if(Input.GetKey(RIGHT)){
            MoveVec += new Vector3(1.0f, 0f, 0f);
        }
        if(MoveVec.magnitude != 0){
            MoveVec /= MoveVec.magnitude;
            MoveVec *= Speed;
            transform.position += MoveVec;
        }
    }
}
