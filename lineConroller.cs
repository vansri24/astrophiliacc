using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRendered lr;
    public List<Transform> points  new List<Transform>();
    public Transform lastPoints;
  
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRendered>();
    }

    private void makeLine(Transform finalPoint)
    {
        if(lastPoints == null)
        {
            lastPoints = finalPoint;
            points.Add(lastPoints);
        }
        else
        {
            points.Add(finalPoint);
            lr.enabled = true;
            SetupLine();
        }
    }

    private void SetupLine()
    {
        int pointLength = points.Count;
        lr.positionCount = pointLength;
        for(int i=0; i<pointLength; i++)
        {
            lr.SetPosition(i,points[i].position)
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePsition);
            RaycastHit20 hit = Physics2D.Raycast( origin worldPoint, direction Vector2.zero);
        
            if(hit.collider != null)
            {
                makeLine(hit.collider.transform);
                print(hit.collider.name);
            }        
        }

    }
}