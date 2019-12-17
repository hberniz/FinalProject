using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public int count=0;
    public Text scoreGT, scoreGO;


    private void Start()
    {
        count = 0;
        SetCountText();
        scoreGO = GameObject.Find("scoreboard").GetComponent<Text>();
        // Get the GUIText Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();                          // 3
        scoreGT.text = "Number of keys obtained: " + count.ToString() + "/4";
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Enemy"))
        {

            //FindObjectOfType<GameManager>().EndGame();
            SceneManager.LoadScene("GameOver");
        }
        if (collidedWith.CompareTag("key"))
        {
            collidedWith.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreGT.text = "Number of keys obtained: " + count.ToString() + "/4";
    }
   

}
