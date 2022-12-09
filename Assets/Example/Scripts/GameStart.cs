using System.Collections;
using AdvancedSceneManager.Callbacks;
using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour, ISceneOpen
{

    public UnityEvent _onGameStart;

    public IEnumerator OnSceneOpen()
    {
        _onGameStart.Invoke();
        yield break;
    }

    void Start()
    {
        //ISceneStart.OnOpen won't be called when entering play mode 
        //from the regular button, let's check for that here
        if (!AdvancedSceneManager.SceneManager.runtime.wasStartedAsBuild)
            Debug.Log("This tutorial has to be started as build (play button in Scene Manager Window)");

    }

}
