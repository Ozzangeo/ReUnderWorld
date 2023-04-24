using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public void ToExit() { Application.Quit(); }
    public void ToStart() { SceneManager.LoadScene("GameScene"); }
}
