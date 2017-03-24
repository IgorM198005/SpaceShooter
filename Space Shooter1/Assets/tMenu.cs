using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Score;

    public bool Paused = false;

    private void OnGUI()
    {        
        GUIStyle style1 = new GUIStyle();

        style1.fontSize = 24;

        style1.normal.textColor = Color.white;

        GUI.Box(new Rect(Screen.width * 0.7f, Screen.height * 0.05f, Screen.width * 0.2f, Screen.height * 0.05f), "Счет: " + Score, style1);
        
        GUI.skin.button.fontSize = 24;

        if (GUI.Button(new Rect(Screen.width * 0.67f, Screen.height * 0.9f, Screen.width * 0.3f, Screen.height * 0.05f), (Time.timeScale == 1) ? "Пауза" : "Продолжить", GUI.skin.button))
        {
            if (Time.timeScale == 0) Time.timeScale = 1;            

            else Time.timeScale = 0;
        }

        if (GUI.Button(new Rect(Screen.width * 0.1f, Screen.height * 0.045f, Screen.width * 0.3f, Screen.height * 0.05f), "Выход", GUI.skin.button))
        {
            SceneManager.LoadScene(0);
        }       
    }
}
