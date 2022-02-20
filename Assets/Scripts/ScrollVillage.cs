using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollVillage : MonoBehaviour
{

    [SerializeField] GameObject spawnLocation;
    [SerializeField] float scrollDirection;
    private float speed;


    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Time.fixedTime >= 50f) {
            speed = scrollDirection * 50;
        } else {
            speed = scrollDirection * Time.fixedTime;
        }

        transform.Translate(0,0, speed);
    }

    private void OnTriggerEnter(Collider col)
    { 
        if (col.tag == "Finish") {
            Invoke("Respawn", 0.65f);
        }

    }

    private void Respawn() {
        transform.position = spawnLocation.transform.position;
    }
}
