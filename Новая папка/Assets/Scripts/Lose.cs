using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Home()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        PlayerController.countHeart = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
