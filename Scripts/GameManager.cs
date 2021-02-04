using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools2D {

    public class GameManager : MonoBehaviour
    {
        private bool gamePause = false;

        public static GameManager instance;

        private bool menuShow = false;
        [Header("References: Menu")]
        [SerializeField]
        private GameObject menuRef;
        [SerializeField]
        private GameObject dialogRef;
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
            if (InputManager.instance.GetExitMenu())
            {
                ShowMenu();
            }
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

        public void ShowMenu()
        {
            menuShow = !menuShow;
            if(menuShow)
            {
                Pause();
            }
            else {
                Resume();
            }

            if (menuRef != null)
            {
                menuRef.SetActive(menuShow);
            }
        }
    }
}
