using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

    void Start () {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        ControlCursor ();
    }

    void ControlCursor () {
        if (Input.GetKeyDown (KeyCode.Tab)) {
            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

} // CursorController