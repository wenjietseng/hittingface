using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatBehavior : MonoBehaviour
{
    public GameManager gameManager;
    public bool isWorn;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hat") && !isWorn)
        {

            // design a snap/wearing function

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hat"))
        {

        }        
    }

    IEnumerator DestroyHat(GameObject hat)
    {
        print(0);
        hat.GetComponent<Rigidbody>().useGravity = false;
        hat.transform.position = this.transform.position + new Vector3(0, 0.15f, 0);

        yield return new WaitForSeconds(3.0f);
        print(1);
        gameManager.AddNewHat();
        Destroy(hat);
        isWorn = false;
        yield return 0;

        // MissingReferenceException: The object of type 'BoxCollider' has been destroyed but you are still trying to access it.
        // Your script should either check if it is null or you should not destroy the object.
        // UnityEngine.Collider.Internal_ClosestPointOnBounds (UnityEngine.Vector3 point, UnityEngine.Vector3& outPos, System.Single& distance) (at <19391519260842408ff993819e8afdf3>:0)
        // UnityEngine.Collider.ClosestPointOnBounds (UnityEngine.Vector3 position) (at <19391519260842408ff993819e8afdf3>:0)
        // OVRGrabber.GrabBegin () (at Assets/Oculus/VR/Scripts/Util/OVRGrabber.cs:249)
        // OVRGrabber.CheckForGrabOrRelease (System.Single prevFlex) (at Assets/Oculus/VR/Scripts/Util/OVRGrabber.cs:222)
        // OVRGrabber.OnUpdatedAnchors () (at Assets/Oculus/VR/Scripts/Util/OVRGrabber.cs:172)
        // OVRGrabber.<Awake>b__25_0 (OVRCameraRig r) (at Assets/Oculus/VR/Scripts/Util/OVRGrabber.cs:111)
        // OVRCameraRig.RaiseUpdatedAnchorsEvent () (at Assets/Oculus/VR/Scripts/OVRCameraRig.cs:290)
        // OVRCameraRig.UpdateAnchors (System.Boolean updateEyeAnchors, System.Boolean updateHandAnchors) (at Assets/Oculus/VR/Scripts/OVRCameraRig.cs:266)
        // OVRCameraRig.Update () (at Assets/Oculus/VR/Scripts/OVRCameraRig.cs:133)


    }

}
