using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3 : MonoBehaviour
{
    public List<Vector3> allPoints = new List<Vector3>();
    public float delay = 3.0f;

    private Vector3 startPosition;
    private Vector3 firstPoint;
    private Vector3 endPoint;
    private List<Vector3> allPointsReturn = new List<Vector3>();
    private float delayTmp = 0.0f;
    private bool playerOnPlatform = false;
    private int count = 0;
    private bool wayBack = false;

    void Start()
    {
        allPoints.Add(new Vector3(0.0f, 0.0f, 10.0f));
        allPoints.Add(new Vector3(0.0f, 7.0f, 0.0f));
        allPoints.Add(new Vector3(15.0f, 0.0f, 0.0f));

        startPosition = transform.position;
        firstPoint = startPosition;

        allPointsReturn.Add(startPosition);
        allPointsReturn.AddRange(allPoints);
    }

    void FixedUpdate()
    {
        Debug.Log("Gracz na platformie = "+playerOnPlatform);
        Debug.Log("Droga powrotna = "+wayBack);
        Debug.Log("Count = " + count);
        Debug.Log("firstPoint = " + firstPoint);
        Debug.Log("endPoint = " + endPoint);

        if(playerOnPlatform && count < allPoints.Count && !wayBack)
        {
            if (delayTmp < delay)
            {
                delayTmp += Time.deltaTime;

                float tmp = delayTmp / delay;
                transform.position = Vector3.Lerp(firstPoint, firstPoint + allPoints[count], tmp);
            }
            else
            {
                firstPoint = firstPoint + allPoints[count];
                Debug.Log("firstPoint = " + firstPoint);
                count += 1;
                delayTmp = 0.0f;
            }
        }
        else if(count == allPoints.Count && !wayBack)
        {
            delayTmp = 0.0f;
            count = allPointsReturn.Count - 1;
            Debug.Log("Count = " + count);
            endPoint = firstPoint;
            firstPoint = startPosition;
            wayBack = true;
        }
        else if((!playerOnPlatform || wayBack) && count > 0)
        {
            if (delayTmp < delay)
            {
                delayTmp += Time.deltaTime;

                float tmp = delayTmp / delay;
                transform.position = Vector3.Lerp(endPoint, endPoint - allPointsReturn[count], tmp);
            }
            else
            {
                endPoint = endPoint - allPointsReturn[count];
                count -= 1;
                Debug.Log("Count = " + count);
                delayTmp = 0.0f;
            }
        }
        else if(count == 0 && wayBack)
        {
            endPoint = allPoints[allPoints.Count - 1];
            delayTmp = 0.0f;
            wayBack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.transform.parent = null;
        }
    }
}
