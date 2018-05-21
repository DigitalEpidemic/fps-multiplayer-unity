using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSShootingControls : NetworkBehaviour {

    private Camera mainCam;

    // Same as FPSController
    private float fireRate = 15f;
    private float nextTimeToFire = 0f;

    [SerializeField]
    private GameObject concreteImpact, bloodImpact;

    public float damageAmount = 5f;

    void Start () {
        mainCam = transform.Find ("FPS View").Find ("FPS Camera").GetComponent<Camera> ();
    }

    void Update () {
        Shoot ();
    }

    void Shoot () {
        if (Input.GetMouseButtonDown (0) && Time.time > nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;

            RaycastHit hit;

            // Infinite raycast
            if (Physics.Raycast (mainCam.transform.position, mainCam.transform.forward, out hit)) {
                if (hit.transform.tag == "Enemy") {
                    CmdDealDamage (hit.transform.gameObject, hit.point, hit.normal);
                } else {
                    // Creates concrete impact effect with proper rotation
                    Instantiate (concreteImpact, hit.point, Quaternion.LookRotation (hit.normal));
                }
            }
        }
    }

    // Can be invoked on the server from a client (Needs Cmd as a prefix)
    [Command]
    void CmdDealDamage (GameObject obj, Vector3 pos, Vector3 rotation) {
        obj.GetComponent<PlayerHealth> ().TakeDamage (damageAmount);
        Instantiate (bloodImpact, pos, Quaternion.LookRotation (rotation));
    }

} // FPSShootingControls