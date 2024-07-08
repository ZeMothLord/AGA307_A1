using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSize targetSize;

    float moveDistance = 500;
    float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TeleportTarget());
        StartCoroutine(Move());
        SetUp(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            targetSize = (TargetSize)Random.Range(0, 3);
            SetUp();
        }
    }
    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance * moveSpeed; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        //rotate object around
        transform.Rotate(Vector3.up * 180);
        //wait 3 secs
        yield return new WaitForSeconds(3);

        StartCoroutine(Move());



    }
    IEnumerator TeleportTarget()
    {
        yield return new WaitForSeconds(3);

        transform.Translate(UnityEngine.Random.Range(-2, 8), UnityEngine.Random.Range(-2, 8), UnityEngine.Random.Range(-2, 8));
        StartCoroutine(TeleportTarget());
    }



    


    void SetUp() 
    {
        if (targetSize == TargetSize.Small)
        {
            transform.localScale = Vector3.one * 0.5f;
            moveSpeed = 5f;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }

        else if (targetSize == TargetSize.Medium)
        {
            transform.localScale = Vector3.one;
            moveSpeed = 2f;
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if (targetSize == TargetSize.Large)
        {
            transform.localScale = Vector3.one * 2f;
            moveSpeed = 0.5f;
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
