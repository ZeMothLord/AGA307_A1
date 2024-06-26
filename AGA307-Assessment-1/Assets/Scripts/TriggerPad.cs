using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change

    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Enter: {other.name}");
        if(other.CompareTag("Player"))
        {
            Debug.Log($"Trigger Enter: {other.name} is tagged player");
            //change the spheres colour to green
            sphere.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Trigger Stay: {other.name} is tagged player");
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale += Vector3.one * 0.01f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            //Change the spheres colour to yellow
            sphere.transform.localScale = Vector3.one;
            sphere.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}

