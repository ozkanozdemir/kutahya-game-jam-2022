using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteScript : MonoBehaviour
{
    private static bool _musicExist;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_musicExist)
        {
            _musicExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}