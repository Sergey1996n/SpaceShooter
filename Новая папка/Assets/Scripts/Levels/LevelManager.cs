using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int countUnlockLevel;
    // Start is called before the first frame update
    public Sprite completedIcon;
    public Sprite unlockedIcon;
    public Sprite lockedIcon;
    void Start()
    {
        if (PlayerPrefs.GetInt("CountUnlockLevel") != 0)
           countUnlockLevel = PlayerPrefs.GetInt("CountUnlockLevel");
        else
        {
            countUnlockLevel = 1;
            PlayerPrefs.SetInt("CountUnlockLevel", countUnlockLevel);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.name = (i + 1).ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            if (i < countUnlockLevel - 1)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = completedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else if (i == countUnlockLevel - 1)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
            }

        }
    }
}
