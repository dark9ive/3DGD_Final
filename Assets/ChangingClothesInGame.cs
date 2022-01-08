using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingClothesInGame : MonoBehaviour
{
    public int hatId, bodyId, shoeId;

    public GameObject hat1, hat2, hat3;
    public GameObject body0, body1, body2, body3;
    public GameObject leftShoe1, rightShoe1, leftShoe2, rightShoe2, leftShoe3, rightShoe3;

    void Start()
    {
        string Outfit = PlayerPrefs.GetString("Outfit");
        hatId = int.Parse(Outfit.Split('-')[0]);
        bodyId = int.Parse(Outfit.Split('-')[1]);
        shoeId = int.Parse(Outfit.Split('-')[2]);

        //ChangeHat(hatId);
        ChangeBody(bodyId);
        //ChangeShoe(shoeId);
    }
    /*void ChangeHat(int id){
        if(id == 1){
            hat1.SetActive(true);
            hat2.SetActive(false);
            hat3.SetActive(false);
        }
        if(id == 2){
            hat1.SetActive(false);
            hat2.SetActive(true);
            hat3.SetActive(false);
        }
        if(id == 3){
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(true);
        }
    }
    */
    void ChangeBody(int id){
        if(id == 0){
            body0.SetActive(true);
            body1.SetActive(false);
            body2.SetActive(false);
            body3.SetActive(false);
        }
        if(id == 1){
            body0.SetActive(false);
            body1.SetActive(true);
            body2.SetActive(false);
            body3.SetActive(false);
        }
        if(id == 2){
            body0.SetActive(false);
            body1.SetActive(false);
            body2.SetActive(true);
            body3.SetActive(false);
        }
        if(id == 3){
            body0.SetActive(false);
            body1.SetActive(false);
            body2.SetActive(false);
            body3.SetActive(true);
        }
    }
    /*
    void ChangeShoe(int id){
        shoeId = id;
        if(id == 1){
            shoe1.SetActive(true);
            shoe2.SetActive(false);
            shoe3.SetActive(false);
        }
        if(id == 2){
            shoe1.SetActive(false);
            shoe2.SetActive(true);
            shoe3.SetActive(false);
        }
        if(id == 3){
            shoe1.SetActive(false);
            shoe2.SetActive(false);
            shoe3.SetActive(true);
        }
    }
    */
}
