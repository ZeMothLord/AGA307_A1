using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad2 : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change

    public int rayDistance = 10;
    Ray ray = new Ray();
    RaycastHit rayHit;

    //void FixedUpdate()
    //{
       // CastRay();
    //}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increas the spheres scale by 0.01 on all axis
            CastRay();
        }
    }


    void CastRay()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out rayHit, rayDistance))
        {
            Debug.Log($"raycast is hitting {rayHit.collider.name}");
            //Depending on the tag turn it 
            if (rayHit.collider.tag == "Target")
            {
                Debug.Log("raycast is target");
                rayHit.collider.GetComponent<MeshRenderer>().material.color = Color.red;

                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("E detected");
                    sphere.transform.localScale += Vector3.one * 0.01f;
                }
            }
        }


    }
}
