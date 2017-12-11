using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static int currScore;
    public static int currLevel = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void NextLevel()
    {
        currLevel += 1;
        SceneManager.LoadScene(currLevel);
    }
}
