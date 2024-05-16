using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringStream : MonoBehaviour
{
    LineRenderer lineRenderer = null;
    Vector3 targetPos = Vector3.zero;


    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    void Update()
    {
        
    }

    public void Begin()
    {
        StartCoroutine(BeginPour());
    }

    IEnumerator BeginPour()
    {
        while(gameObject.activeSelf)
        {
            targetPos = FindEndPoint();

            MoveToPosition(0, transform.position);
            MoveToPosition(1, targetPos);

            yield return null;
        }
    }

    Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    void MoveToPosition(int index, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index, targetPosition);
    }
}
