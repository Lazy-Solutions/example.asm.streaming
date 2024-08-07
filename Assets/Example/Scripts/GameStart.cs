﻿using System.Collections;
using AdvancedSceneManager;
using AdvancedSceneManager.Callbacks;
using AdvancedSceneManager.Core;
using AdvancedSceneManager.Models;
using UnityEngine;

public class GameStart : MonoBehaviour, ISceneOpenAsync
{

    public Scene[] scenesToOpen;

    public IEnumerator OnSceneOpen()
    {
        //We're creating a scene operation directly here, since we need to ignore the queue,
        //as ASM will otherwise freeze (as multiple items in the queue are waiting for each other)
        yield return SceneOperation.Start().Open(scenesToOpen);
    }

    void Start()
    {
        //ISceneStart.OnOpen won't be called when entering play mode 
        //from the regular button, let's check for that here
        if (!SceneManager.app.isBuildMode)
            Debug.Log("This tutorial has to be started as build (play button in Scene Manager Window)");

    }

}
