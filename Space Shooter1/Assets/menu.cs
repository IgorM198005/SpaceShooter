using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public GUIStyle mystyle;

    void OnGUI()
    {

        GUI.skin.button.fontSize = 30;

        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.10f, Screen.width * 0.7f, Screen.height * 0.1f), "СТАРТ", GUI.skin.button))
        {
            SceneManager.LoadScene(1);//Загрузка игровой сцены
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.25f, Screen.width * 0.7f, Screen.height * 0.1f), "ПРИСОЕДИНИТСЯ", GUI.skin.button))
        {
            
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.4f, Screen.width * 0.7f, Screen.height * 0.1f), "ВЫЙТИ ИЗ ИГРЫ", GUI.skin.button))
        {
            Application.Quit();//Выход из игры
        }
    }
}
