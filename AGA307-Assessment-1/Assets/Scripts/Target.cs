using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetSize targetSize;


    // Start is called before the first frame update
    void Start()
    {
        SetUp(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetUp() 
    {
        if (targetSize == TargetSize.Small)
            transform.localScale = Vector3.one * 0.5f;
        else if (targetSize == TargetSize.Medium)
            transform.localScale = Vector3.one;
        else if (targetSize == TargetSize.Large)
            transform.localScale = Vector3.one * 2f;
    }
}
