using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public int rayDistance = 10;
    Ray ray = new Ray();
    RaycastHit rayHit;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


    }

    void FixedUpdate()
    {
        CastRay();
    }



    void CastRay()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out rayHit, rayDistance))
        {





            //Print name of what was hit
           // Debug.Log($"{rayHit.collider.name}");
            //Depending on the tag turn it blue
            if(rayHit.collider.tag == "Target")
                rayHit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
