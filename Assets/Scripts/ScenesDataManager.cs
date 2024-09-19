using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesDataManager : MonoBehaviour
{
    public static ScenesDataManager instance;

    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
