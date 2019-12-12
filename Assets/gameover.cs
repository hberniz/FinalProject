using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        // Draw the GUI button for view switching at the top of the screen
        Rect buttonRect = new Rect((Screen.width / 2) - 50, 10, 100, 24);
        if (GUI.Button(buttonRect, "Restart"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
