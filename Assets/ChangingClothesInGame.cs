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

        ChangeHat(hatId);
        ChangeBody(bodyId);
        ChangeShoe(shoeId);
    }
    void ChangeHat(int id){
        if(id == 0){
            hat1.SetActive(false);
            hat2.SetActive(false);
            hat3.SetActive(false);
        }
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
    void ChangeShoe(int id){
        if(id == 0){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);
        }
        if(id == 1){
            leftShoe1.SetActive(true);
            rightShoe1.SetActive(true);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);
        }
        if(id == 2){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(true);
            rightShoe2.SetActive(true);
            leftShoe3.SetActive(false);
            rightShoe3.SetActive(false);
        }
        if(id == 3){
            leftShoe1.SetActive(false);
            rightShoe1.SetActive(false);
            leftShoe2.SetActive(false);
            rightShoe2.SetActive(false);
            leftShoe3.SetActive(true);
            rightShoe3.SetActive(true);
        }
    }
}
