using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARCursor : MonoBehaviour
{
    public GameObject CursorChildObject;
    public GameObject ObjectToPlace;
    public ARRaycastManager ARRaycastManager;

    public bool useCursor = true;
    
    void Start()
    {
        CursorChildObject.SetActive(useCursor);
    }
    
    void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (useCursor)
            {
                Instantiate(ObjectToPlace, transform.position, transform.rotation);
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                ARRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
                if (hits.Count > 0)
                {
                    Instantiate(ObjectToPlace, hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        }
    }

    private void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(screenPosition,hits,TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
