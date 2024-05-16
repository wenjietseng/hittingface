using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetController : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject hmd;
    public GameObject leftAnchor;
    public GameObject leftController;
    public GameObject realLeftController;
    public GameObject rightAnchor;
    public GameObject rightController;
    public GameObject realRightController;


    [Header("Global Settings")]
    public static bool isAppliedOffest;
    public bool showRealLeftControllerPosition;
    public bool showRealRightControllerPosition;
    public enum ApplyOffset {None=0, Always=1, Random=2};
    public ApplyOffset howToApplyOffset;
    
    // helpers
    public static Vector3 startingPos;
    public static Vector3 endingLocalPos;
    public static bool isGrabbed;
    public AnimationCurve curve;
    public float dist;
    public float x;
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    Vector3 oldLocalPos;

    void Start()
    {
        ShowRealControllers();
        
    }

    void Update()
    {
        ShowRealControllers();

        Debug.DrawRay(realRightController.transform.position, realRightController.transform.forward, Color.red, 0.2f);
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        if (isGrabbed)
        {   
            
            // how to know which hand grab?
            
            // might work in mask context
            // probelm of hat: the hand rotates.

            // remove snapping


            /////////////////////
            if (isAppliedOffest)
            {
                // dist = (hmd.transform.position - rightAnchor.transform.position).magnitude;
                // float ratio = dist / (hmd.transform.position - startingPos).magnitude; // this ->> hmd + random perhaps.
                // rightController.transform.localPosition = new Vector3(0, 0,  -curve.Evaluate(1-ratio) * x);
                dist = Mathf.Abs(hmd.transform.position.z - rightAnchor.transform.position.z);
                float ratio = dist / Mathf.Abs(hmd.transform.position.z - startingPos.z); // this ->> hmd + random perhaps.
                rightController.transform.localPosition = new Vector3(0, -curve.Evaluate(1-ratio) * x, -curve.Evaluate(1-ratio) * x);
            }
            
            
            // float ratio = dist / (this.transform.position - startingPos).magnitude; // this ->> hmd + random perhaps.
            // rightController.transform.localPosition = new Vector3(0, -curve.Evaluate(ratio) * x, 0);
        }
        else
        {
            if (rightController.transform.localPosition.magnitude > 0)
            {
                
                rightController.transform.localPosition = Vector3.Lerp(endingLocalPos, Vector3.zero, interpolationRatio);
            }
        }
    }

    void ShowRealControllers()
    {
        if (showRealLeftControllerPosition) realLeftController.SetActive(true);
        else realLeftController.SetActive(false);
        if (showRealRightControllerPosition) realRightController.SetActive(true);
        else realRightController.SetActive(false);
    }

}
