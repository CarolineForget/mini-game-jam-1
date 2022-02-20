using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points;
    [SerializeField] private Text txt_points;
    private Scene scene;

    void Start() {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "EndingScene") {
            points = PlayerPrefs.GetInt("Score");
        } else {
            points = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        txt_points.text = points.ToString();
        PlayerPrefs.SetInt("Score", points);
    }

    public void Retry() {
        SceneManager.LoadScene("Game1");
    }
}
