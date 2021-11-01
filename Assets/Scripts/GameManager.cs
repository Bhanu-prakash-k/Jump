using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt("LevelLoad", 0);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("LevelLoad",0));
        levelText.text = "Level - " + SceneManager.GetActiveScene().buildIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SkipButton()
	{
		PlayerPrefs.SetInt("LevelLoad", PlayerPrefs.GetInt("LevelLoad", 1) + 1);
		SceneManager.LoadScene(PlayerPrefs.GetInt("LevelLoad", 1));
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
