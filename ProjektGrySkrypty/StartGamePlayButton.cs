using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePlayButton : MonoBehaviour
{
    public Canvas StartCanvas;
    public Canvas ChooseCharacterCanvas;
    public GameObject Button;

    public void StartGame()
    {
        if (Button != null)
        {
            StartCanvas.gameObject.SetActive(false);
            ChooseCharacterCanvas.gameObject.SetActive(true);
        }
    }
}
