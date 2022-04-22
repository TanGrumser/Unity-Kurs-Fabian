using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public GameObject pipePrefab;
    float counter = 1.5f;
    public static int score =0;

    public static bool isGameRunning = true;
    public static bool hasGameStarted =false;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start(){
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

            Instantiate(pipePrefab, new Vector3(15f, height, 0f), Quaternion.identity);
            counter = 3f;
        }
    }
    public void Drawscore() {
        scoreText.text = "Score: " + score;
    }
}
