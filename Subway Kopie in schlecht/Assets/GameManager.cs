using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject[] einshocheinsgrade;
    float counter = 0f;
    float scoreCounter = 1.7f;
    public static int score = 0;

    public static bool isGameRunning = true;
    public static bool hasGameStarted =true;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start(){
        score = 0;
        if (instance == null) {
            instance = this;
        }else if (instance != this) {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update() {
        if (hasGameStarted == false) {
            return;
        }
        if (isGameRunning == false) {
            return;
        }
        counter -= Time.deltaTime;

        if (counter < 0f) {
            float height = Random.Range(-1f, 2f);
            GameObject zufallsObstacle = einshocheinsgrade[Random.Range(0, einshocheinsgrade.Length)];

            Instantiate(zufallsObstacle, new Vector3(15f, -1.46f , 0f), Quaternion.identity);
            counter = 5f;
        }
            Drawscore();
    }
    public void Drawscore(){
        
        if (scoreCounter < 0f) {
            scoreText.text = "Score: " + score;
            score++;
            scoreCounter = 5f;
        } else {
            scoreCounter -= Time.deltaTime;
        }
        if (isGameRunning == false) {
            score = 0;
        }
    }
}