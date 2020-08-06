using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.startCountHealt = PlayerPrefs.GetInt("StartCountHeart");
        LevelManager.countUnlockLevel = PlayerPrefs.GetInt("CountUnlockLevel");
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("StartCountHeart", PlayerController.startCountHealt);
        PlayerPrefs.SetInt("CountUnlockLevel", LevelManager.countUnlockLevel);
    }
}
