using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Setsingleplayer()
    {
        GameValues.IsMultiplayer = false;
    }

    public void SetMultiplayer()
    {
        GameValues.IsMultiplayer = true;
    }
}
