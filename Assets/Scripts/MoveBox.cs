using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private GameObject gameManager;

    void Start() {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * -12.5f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "Finish") {
            gameManager.GetComponent<GameManager>().points ++;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Box") {
            Destroy(col.gameObject);
        }
    }
}
