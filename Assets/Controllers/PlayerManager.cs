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
    GameObject[] finishObjects;

    private void Start()
    {
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        hideFinished();
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Enemy"))
        {

            //FindObjectOfType<GameManager>().EndGame();
            SceneManager.LoadScene("GameOver");
        }
    }




    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }

    }
    //hides objects with ShowOnFinish tag
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene("Game");
    }
   
}
