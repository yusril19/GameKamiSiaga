using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioBackGround");
        if(objs.Length>1)
        {
            Destroy(this.gameObject);
        }

         DontDestroyOnLoad(this.gameObject);
    }

}
