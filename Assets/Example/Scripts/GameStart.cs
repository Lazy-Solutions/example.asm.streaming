using System.Collections;
using AdvancedSceneManager;
using AdvancedSceneManager.Callbacks;
using AdvancedSceneManager.Core;
using AdvancedSceneManager.Models;
using UnityEngine;

public class GameStart : MonoBehaviour, ISceneOpen
{

    public Scene[] scenesToOpen;

    public IEnumerator OnSceneOpen()
    {
        //We're creating a scene operation directly here, since we need to ignore the queue,
        //as ASM will otherwise freeze (due too the queuing system)
        yield return SceneOperation.Add(SceneManager.standalone, ignoreQueue: true).Open(scenesToOpen);
    }

    void Start()
    {
        //ISceneStart.OnOpen won't be called when entering play mode 
        //from the regular button, let's check for that here
        if (!AdvancedSceneManager.SceneManager.runtime.wasStartedAsBuild)
            Debug.Log("This tutorial has to be started as build (play button in Scene Manager Window)");

    }

}
