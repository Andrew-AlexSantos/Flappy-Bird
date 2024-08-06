using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

[FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;
    public float objectSpeed = 10;

    public float obstaclecOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    [HideInInspector]
    public int score;

    private bool isGameOver = false;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameActive() {
        return !isGameOver;
    }
    public bool IsGameOver() {
        return isGameOver;
    }
    public void EndGame() {
        // Set flag
        isGameOver = true;

        // Print message
        Debug.Log("Game over... You score was " + score + "!! ");

        // Reload Scene
        StartCoroutine(ReloadScene(2));

    }

    private IEnumerator ReloadScene(float delay) {
        // Wait
        yield return new WaitForSeconds(delay);

        // Recarregar a cena
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        
    }

}
