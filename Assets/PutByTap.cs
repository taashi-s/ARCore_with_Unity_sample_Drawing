using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PutByTap : MonoBehaviour
{
    public GameObject pown;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if ( Input.touchCount < 1 ) {
            return;
        }
        Touch touch = Input.GetTouch (0);

        if ( touch.phase != TouchPhase.Moved ) {
            return;
        }

        TrackableHit hit;
        TrackableHitFlags filter = TrackableHitFlags.PlaneWithinPolygon;
        if (Frame.Raycast(touch.position.x, touch.position.y, filter, out hit)) {
            if (hit.Trackable is DetectedPlane){
                pown.transform.position = hit.Pose.position;
                pown.transform.rotation = hit.Pose.rotation;
                pown.transform.Rotate(0, 180, 0, Space.Self);

                var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                pown.transform.parent = anchor.transform;
            }
        }
    }
}
