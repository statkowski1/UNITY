using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    public Canvas CanvasObject;
    public Canvas CanvasChooseCharacter;
    public GameObject Button;
    public GameObject Player;
    public GameObject Spawner;
    public GameObject Camera;

    public void ChooseCharacterAndStartGame()
    {
        if(Button != null)
        {
            CanvasObject.gameObject.SetActive(true);
            Player.SetActive(true);
            Spawner.SetActive(true);
            CanvasChooseCharacter.gameObject.SetActive(false);
            Camera.SetActive(false);
        }
    }
}
