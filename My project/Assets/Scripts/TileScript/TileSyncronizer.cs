using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSyncronizer : MonoBehaviour
{
    public int varient = 6;

    void Start(){
        for(int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).gameObject.GetComponent<Animator>().SetInteger("varient", varient);
        }
    }
}
