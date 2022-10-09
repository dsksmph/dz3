using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;
        public static int levelNumber { get; private set; } = 0;

        private void Awake()
        {
            instance = this;
        }

        public void TryLoadNextLevel()
        {
            switch (levelNumber)
            {
                case 0:
                    SceneManager.UnloadScene(levelNumber);
                    levelNumber = 1;
                    SceneManager.LoadScene(levelNumber);
                    break;
                case 1:
                    SceneManager.UnloadScene(levelNumber);
                    levelNumber = 2;
                    SceneManager.LoadScene(levelNumber);
                    break;
                case 2:
                    SceneManager.UnloadScene(levelNumber);
                    levelNumber = 0;
                    SceneManager.LoadScene(levelNumber);
                    break;

            }
        }
    }
}
