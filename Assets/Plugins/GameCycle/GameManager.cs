using System;
using System.Collections.Generic;
using SampleGame;
using UnityEngine;

namespace Plugins.GameCycle
{
    public sealed class GameManager
    {
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;
        
        public GameState State { get; private set; }
        private readonly List<IGameListener> listeners = new();
        

        public void AddListener(IGameListener listener) => 
            listeners.Add(listener);

        public void RemoveListener(IGameListener listener) => 
            listeners.Remove(listener);

        public void StartGame()
        {
            if (State != GameState.OFF)
                return;

            //Cursor.lockState = CursorLockMode.Locked;
           // Cursor.visible = false;
            Time.timeScale = 1;
            foreach (var it in listeners)
            {
                if (it is IGameStartListener listener) 
                    listener.OnStartGame();
            }
            
            State = GameState.PLAY;
            OnGameStarted?.Invoke();
            Debug.Log("Game Started");
        }

        public void PauseGame()
        {
            if (State != GameState.PLAY)
                return;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            foreach (var it in listeners)
            {
                if (it is IGamePauseListener listener) 
                    listener.OnPauseGame();
            }
            
            State = GameState.PAUSE;
            OnGamePaused?.Invoke();
            Debug.Log("Game Paused");
        }
        
        public void ResumeGame()
        {
            if (State != GameState.PAUSE)
                return;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            foreach (var it in listeners)
            {
                if (it is IGameResumeListener listener) 
                    listener.OnResumeGame();
            }
            
            State = GameState.PLAY;
            OnGameResumed?.Invoke();
            Debug.Log("Game Resumed");
        }
        
        public void FinishGame()
        {
            if (State is not (GameState.PAUSE or GameState.PLAY))
                return;
            
            foreach (var it in listeners)
            {
                if (it is IGameFinishListener listener) 
                    listener.OnFinishGame();
            }
            
            State = GameState.FINISH;
            OnGameFinished?.Invoke();
            Debug.Log("Game Finished");
        }
    }
}