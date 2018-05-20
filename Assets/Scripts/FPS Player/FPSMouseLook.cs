using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseLook : MonoBehaviour {

    public enum RotationAxis {
        MouseX,
        MouseY
    }

    public RotationAxis axis = RotationAxis.MouseY;

    private float currentSensitivity_X = 1.5f;
    private float currentSensitivity_Y = 1.5f;

    private float sensitivity_X = 1.5f;
    private float sensitivity_Y = 1.5f;

    private float rotation_X, rotation_Y;

    private float minimum_X = -360f;
    private float maximum_X = 360f;

    private float minimum_Y = -60f;
    private float maximum_Y = 60f;

    private Quaternion originalRotation;

    private float mouseSensitivity = 1.7f;

    void Start () {
        originalRotation = transform.rotation;
    }

    void LateUpdate () {
        HandleRotation ();
    }

    float ClampAngle (float angle, float min, float max) {
        if (angle < -360f) {
            angle += 360f;
        }

        if (angle > 360f) {
            angle -= 360f;
        }

        return Mathf.Clamp (angle, min, max);
    }

    void HandleRotation () {
        // Precaution code
        if (currentSensitivity_X != mouseSensitivity || currentSensitivity_Y != mouseSensitivity) {
            currentSensitivity_X = currentSensitivity_Y = mouseSensitivity;
        }

        sensitivity_X = currentSensitivity_X;
        sensitivity_Y = currentSensitivity_Y;

        if (axis == RotationAxis.MouseX) {
            rotation_X += Input.GetAxis ("Mouse X") * sensitivity_X;

            rotation_X = ClampAngle (rotation_X, minimum_X, maximum_X);
            Quaternion xQuaternion = Quaternion.AngleAxis (rotation_X, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }

        if (axis == RotationAxis.MouseY) {
            rotation_Y += Input.GetAxis ("Mouse Y") * sensitivity_Y;

            rotation_Y = ClampAngle (rotation_Y, minimum_Y, maximum_Y);
            Quaternion yQuaternion = Quaternion.AngleAxis (-rotation_Y, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

} // FPSMouseLook