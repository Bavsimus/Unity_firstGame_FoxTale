using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimations : MonoBehaviour
{
    private enum anim { Idle};
    // Start is called before the first frame update
    void Start()
    {
        animations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void animations()
    {
        anim state;
        state = anim.Idle;
    }
}
