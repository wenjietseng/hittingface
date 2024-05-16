using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingFaceControl : MonoBehaviour
{
    // public OVRInput.Controller left;
    // public OVRInput.Controller right;
    
    // public Transform leftRenderedModel;
    // public Transform rightRenderedModel;
    // public float cdRatio = 1.0f;
    // float leftTriggerValue;
    // float rightTriggerValue;
    [Header("Drink GameObjects")]
    public GameObject[] lightDrinkPrefabs;
    public GameObject[] mediumDrinkPrefabs;
    public GameObject[] largeDrinkPrefabs;

    public GameObject drinkSpawningPos;
    public bool isDrinkFinished = false;
    public int drinkedNumber = 0;
    public GameObject currentDrink;
    public float smallDrink = 10f;
    public float mediumDrink = 15f;
    public float largeDrink = 30f;
    public static float drinkTime = 0f;
    
    [Header("Interactions")]
    public GameObject hmd;
    public GameObject leftController;
    private OVRGrabber leftGrabber;
    public GameObject rightController;
    public GameObject rightHandAnchor;
    private OVRGrabber rightGrabber;

    public Vector3 originalPos;
    public float decreasePercentage;
    public float lightWeight = 0.975f;
    public float mediumWeight = 0.95f;
    public float largeWeight = 0.90f;
    public bool isGrabbed;
    private float offsetLimit = 0.24f;
    public float currentOffset = 0.0f;

    public Vector3 realHand2OriginalPos;
    Vector3 visualPos;

    public AudioSource openCan;

    void Start()
    {
        leftGrabber = leftController.GetComponent<OVRGrabber>();
        rightGrabber = rightController.GetComponent<OVRGrabber>();
        drinkedNumber = 0;
        ServeOneDrink();

    }

    void Update()
    {
        // leftTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, left); 
        // rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, right); 
        // print(leftTriggerValue + ", " + rightTriggerValue);

        Vector3 leftTempPos = leftController.transform.position;
        Vector3 rightTempPos = rightController.transform.position;

        if (isGrabbed)
        {
            if (currentOffset <= offsetLimit)
            {
                realHand2OriginalPos = rightHandAnchor.transform.position - originalPos;
                // Debug.DrawRay(originalPos, realHand2OriginalPos, Color.red, 0.1f);

                
                visualPos = realHand2OriginalPos * decreasePercentage;
                Debug.DrawRay(originalPos+visualPos, -(visualPos - realHand2OriginalPos), Color.green, 0.2f);
                rightController.transform.position = (originalPos + visualPos);

                // rightController.transform.localPosition = -(decreasePercentage) * realHand2OriginalPos;
            }
            currentOffset = (visualPos - realHand2OriginalPos).magnitude;
        }
        else
        {
            if (isDrinkFinished)
            {            
                drinkedNumber += 1;
                GameObject go2Destroy = currentDrink.gameObject;
                StartCoroutine(DestroyEmptyCan(go2Destroy));
                ServeOneDrink();
            }
        }


        // Gameflow
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDrinkFinished = true;
            drinkedNumber += 1;
        }

        if (drinkTime < 0.0f & !isDrinkFinished)
        {
            isDrinkFinished = true;
        }



    }

    void ServeOneDrink()
    {
        int idx = 0;
        if (drinkedNumber % 3 == 0)
        {
            idx = Random.Range(0, lightDrinkPrefabs.Length);
            currentDrink = Instantiate(lightDrinkPrefabs[idx], drinkSpawningPos.transform.position, Quaternion.identity);
            currentDrink.transform.Rotate(new Vector3(0,90,0), Space.Self);
            decreasePercentage = lightWeight;
            drinkTime = smallDrink;
        }
        else if (drinkedNumber % 3 == 1)
        {
            idx = Random.Range(0, mediumDrinkPrefabs.Length);
            currentDrink = Instantiate(mediumDrinkPrefabs[idx], drinkSpawningPos.transform.position, Quaternion.identity);
            currentDrink.transform.Rotate(new Vector3(0,180,0), Space.Self);
            decreasePercentage = mediumWeight;
            drinkTime = mediumDrink;
        }
        else
        {
            idx = Random.Range(0, largeDrinkPrefabs.Length);
            currentDrink = Instantiate(largeDrinkPrefabs[idx], drinkSpawningPos.transform.position, Quaternion.identity);
            currentDrink.transform.Rotate(new Vector3(0,-90,0), Space.Self);
            decreasePercentage = largeWeight;
            drinkTime = largeDrink;
        }
        isDrinkFinished = false;
        openCan.Play();
    }


    IEnumerator DestroyEmptyCan(GameObject go2Destroy)
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(go2Destroy);
        yield return 0;
    }

}
