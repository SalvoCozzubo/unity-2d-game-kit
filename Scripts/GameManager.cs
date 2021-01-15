using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gamePause = false;

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGamePause()
    {
        return gamePause;
    }

    public void Pause()
    {
        gamePause = true;
    }

    public void Resume()
    {
        gamePause = false;
    }
}
