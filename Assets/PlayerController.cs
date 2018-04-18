using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<playermoment> Players = new List<playermoment>();

    public GameObject AiPlayer;

    void Start()
    {
        if (GameValues.IsMultiplayer)
        {
            AiPlayer.GetComponent<playermoment>().enabled = true;
            AiPlayer.GetComponent<aiscript>().enabled = false;
        }
        else
        {
            AiPlayer.GetComponent<playermoment>().enabled = false;
            AiPlayer.GetComponent<aiscript>().enabled = true;
        }
    }
    
    void FixedUpdate()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var player in Players)
            {
                if (player.LockedFingerID == null)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began &&
                        player.PlayerCollider.OverlapPoint(touchWorldPos))
                    {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if (player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    player.MoveToPosition(touchWorldPos);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended ||
                        Input.GetTouch(i).phase == TouchPhase.Canceled)
                        player.LockedFingerID = null;
                }
            }
        }
    }
}