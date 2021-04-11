using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LoseWinFuncs();
public class GameController : MonoBehaviour
{
    public LoseWinFuncs onWinFunctions;
    public LoseWinFuncs onLoseFunctions;
    private void Start() {
        onWinFunctions += FindObjectOfType<TouchControl>().OnWin;
        onWinFunctions += FindObjectOfType<Exit>().OnWin;
        onWinFunctions += FindObjectOfType<Player>().OnWin;

        onLoseFunctions += FindObjectOfType<TouchControl>().OnLose;
    }
}
