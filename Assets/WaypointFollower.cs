using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoint;
    private int currentWaypCoord = 0;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoint[currentWaypCoord].transform.position,transform.position) < .1f)
        {
            currentWaypCoord++;
            if (currentWaypCoord >= waypoint.Length)
            {
                currentWaypCoord = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypCoord].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
