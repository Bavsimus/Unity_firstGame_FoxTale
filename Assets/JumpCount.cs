using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCount : MonoBehaviour
    {
    public int MyVariable;
    // Start is called before the first frame update
    void Start()
    {
        MyVariable = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
                MyVariable++;
        }
    }

    public int MyFunc()
    {
        return 0;
    }
    }