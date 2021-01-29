using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Draw : MonoBehaviour
{
    public GameObject obj;
    GameObject drawObj;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if ( Input.touchCount == 1 ) {
            Vector3 p = Camera.main.transform.TransformPoint(0, 0, 0.1f);

            if ( Input.GetTouch(0).phase == TouchPhase.Began ) {
                drawObj = GameObject.Instantiate(obj, p, Quaternion.identity);
            }
        else if ( Input.GetTouch(0).phase == TouchPhase.Stationary ) {
            drawObj.transform.position = p;
        }
        }
    }
}
