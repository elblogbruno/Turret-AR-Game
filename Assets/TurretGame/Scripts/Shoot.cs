using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject turret;

    void Update(){

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get the touch position from the screen touch to world point
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            // Raycast to the touched position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Touched " + hit.collider.gameObject.name);

                turret.GetComponent<TurretAI>().currentTarget = hit.collider.gameObject;
                turret.GetComponent<TurretAI>().Shoot(hit.transform.gameObject);
            }else
            {
                Debug.Log("Touched nothing");
            }
        }
    }
}
