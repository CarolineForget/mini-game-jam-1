using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private Transform boxPfb;
    private Transform box;

    private float randomNumber;
    private float delay = 8f;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, delay);

        Invoke("SpawnBoxes", randomNumber);
    }

    private void FixedUpdate() {
        if (gameManager.GetComponent<GameManager>().points >= 40) {
            delay = 1.85f;

        } else if (gameManager.GetComponent<GameManager>().points >= 30) {
            delay = 3f;

        } else if (gameManager.GetComponent<GameManager>().points >= 20) {
            delay = 4.5f;

        } else if (gameManager.GetComponent<GameManager>().points >= 10) {
            delay = 6.5f;
        }

    }

    private void SpawnBoxes() {
        //box = Instantiate(boxPfb, new Vector3(Random.Range(-20f, 20f), 20f, Random.Range(-20f, 15f)), Quaternion.identity, parent.transform);
        box = Instantiate(boxPfb, new Vector3(parent.transform.position.x, parent.transform.position.y ,parent.transform.position.z), Quaternion.identity, parent.transform);
        box.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        box.name = "Box Spawned";

        randomNumber = Random.Range(0, delay);
        Invoke("SpawnBoxes", randomNumber);
    }
}
