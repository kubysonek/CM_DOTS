using System;
using UnityEngine;


public class MouseWorldPosition : MonoBehaviour {
    
    public static MouseWorldPosition Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    public Vector3 GetPosition() {
        Ray mouseCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(mouseCameraRay, out float distance)) {
            return mouseCameraRay.GetPoint(distance);
        }
        else {
            return Vector3.zero;
        }
        
        // Physics approach -> better if map is not flat
        // Ray mouseCameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(mouseCameraRay, out RaycastHit raycastHit)) {
        //     return raycastHit.point;
        // }
    }
}