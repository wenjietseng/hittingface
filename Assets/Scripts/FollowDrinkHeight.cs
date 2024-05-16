using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDrinkHeight : MonoBehaviour
{
    public HittingFaceControl hittingFaceControl;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = hittingFaceControl.currentDrink.transform.GetChild(0).GetComponent<Wobble>().lastPos;
        this.transform.position = new Vector3(offset.x, offset.y + hittingFaceControl.currentDrink.transform.GetChild(0).GetComponent<Renderer>().material.GetFloat("_FillAmount"), offset.z); 
    
        print(hittingFaceControl.currentDrink.transform.GetChild(0).GetComponent<Renderer>().material.GetVector("worldPosAdjusted"));
    }
}
