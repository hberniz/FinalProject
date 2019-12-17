using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class key : MonoBehaviour
{
    public int keyhold=0;
    int playerkey = PlayerManager.instance.count;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Player"))
        {
            playerkey = PlayerManager.instance.count;
            if (playerkey >= keyhold)
            {
                door.SetActive(false);
            }
        }
    }
}
