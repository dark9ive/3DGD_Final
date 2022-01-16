using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMoveCam : MonoBehaviour{
    public GameObject player;
    public Camera MainCam;
    public float X_min;
    public float X_max;
    public float Z_min;
    public float Z_max;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if(player.transform.position.x - MainCam.transform.position.x <= X_min){
            MainCam.transform.position += new Vector3(player.transform.position.x - MainCam.transform.position.x - X_min, 0f, 0f);
        }
        if(player.transform.position.x - MainCam.transform.position.x >= X_max){
            MainCam.transform.position += new Vector3(player.transform.position.x - MainCam.transform.position.x - X_max, 0f, 0f);
        }
        if(player.transform.position.z - MainCam.transform.position.z <= Z_min){
            MainCam.transform.position += new Vector3(0f, 0f, player.transform.position.z - MainCam.transform.position.z - Z_min);
        }
        if(player.transform.position.z - MainCam.transform.position.z >= Z_max){
            MainCam.transform.position += new Vector3(0f, 0f, player.transform.position.z - MainCam.transform.position.z - Z_max);
        }
    }

}
