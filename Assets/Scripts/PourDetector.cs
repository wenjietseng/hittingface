using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject pour;
    AudioSource bubbling;
    AudioSource gulping;

    private bool isPouring = false;
    
    void Awake()
    {
        bubbling = GameObject.Find("Bubbling").GetComponent<AudioSource>();
        gulping = GameObject.Find("Gulping").GetComponent<AudioSource>();
        // lineRenderer = GetComponent<LineRenderer>();
    }
    
    void Start()
    {
        pour.SetActive(false);
        // MoveToPosition(0, origin.position);
        // MoveToPosition(1, origin.position);
    }

    void Update()
    {
        bool pourCheck = CalculatePourAngle() > pourThreshold;


        if (isPouring)
        {
            FindEndPoint();
            HittingFaceControl.drinkTime -= Time.deltaTime;


            // MoveToPosition(0, origin.position);
            // Vector3 targetPos = FindEndPoint();
            // MoveToPosition(1, targetPos);
        }

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }

        }

        if (HittingFaceControl.drinkTime < 0)
        {
            this.GetComponent<PourDetector>().enabled = false;
            bubbling.Stop();
            gulping.Stop();
            pour.SetActive(false);
        }
    }

    void StartPour()
    {
        pour.SetActive(true);
        bubbling.Play();
        print("Start pour");

        // Vector3 targetPos = FindEndPoint();
        // MoveToPosition(0, origin.position);
        // MoveToPosition(1, targetPos);
    }

    void EndPour()
    {
        print("End pour");
        pour.SetActive(false);
        bubbling.Stop();

        // MoveToPosition(0, origin.position);
        // MoveToPosition(1, origin.position);
    }

    float CalculatePourAngle()
    {
        return Vector3.Angle(this.transform.up, Vector3.up);
    }

    Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(origin.position, Vector3.down);

        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.transform.name == "Sphere" && !gulping.isPlaying)
        {
            gulping.Play();
        }
        else
        {
            gulping.Stop();
        }
        Vector3 endPoint = ray.GetPoint(0.3f);


        return endPoint;
    }

    // void MoveToPosition(int index, Vector3 targetPosition)
    // {
    //     lineRenderer.SetPosition(index, targetPosition);
    // }
}
