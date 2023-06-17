using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimations : MonoBehaviour
{
    public Scripts player_Movement;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_Movement.frogAttState = true;
        }
    }


    private void animations()
    {
        anim state;
        state = anim.Idle;
    }
}
