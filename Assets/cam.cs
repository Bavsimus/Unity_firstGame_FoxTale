using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [SerializeField] private Transform nigga;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(nigga.position.x, transform.position.y, transform.position.z);
    }
}
