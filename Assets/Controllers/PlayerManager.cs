using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int count;
    public Text countText;


    private void Start()
    {
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Enemy"))
        {

            //FindObjectOfType<GameManager>().EndGame();
            SceneManager.LoadScene("GameOver");
        }
        if(collidedWith.CompareTag("key"))
        {
            collidedWith.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        void SetCountText()
        {
            countText.text = "Number of keys obtained: " + count.ToString() + "/4";
        }


     

}
