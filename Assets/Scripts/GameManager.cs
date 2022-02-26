using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootRun
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        public static event Action LevelLoaded;
        
        [SerializeField] private List<LevelBehaviour> _levels = new List<LevelBehaviour>();

        public int CurrentLevel;

        private LevelBehaviour _level;

        private void Start()
        {
            if (_levels.Count < 1)
            {
                Debug.LogError("No levels found");
                return;
            }
            LoadLevel();
        }

        public void LoadLevel()
        {
            if(_level)
                DestroyImmediate(_level.gameObject);
            
            _level = Instantiate(_levels[CurrentLevel % _levels.Count]);
        }

        public void FinishGame(bool success)
        {
            if (success)
                CurrentLevel++;
            
            UIController.Instance.ActivateEndgamePanel(success);
        }
    }
}

