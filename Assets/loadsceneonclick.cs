﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadsceneonclick : MonoBehaviour {

    public void loadbyindex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
}
