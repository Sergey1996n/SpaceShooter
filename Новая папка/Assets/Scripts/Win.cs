using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 == LevelManager.countUnlockLevel)
            LevelManager.countUnlockLevel++;
        PlayerController.startCountHealt = PlayerController.countHeart;
    }

// Update is called once per frame
void Update()
    {
        
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

