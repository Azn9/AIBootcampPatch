using System;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace AIBootcampPatch
{
    public class AIBootcampPatch : MelonMod
    {
        private bool _rewindFast;
        private long _rewindFastTime;
        private Button _rewindButton;

        private bool _forwardFast;
        private long _forwardFastTime;
        private Button _forwardButton;

        private Button _pauseButton;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            var bbObj = GameObject.Find("ButtonBar");

            if (!bbObj)
            {
                MelonLogger.Warning("ButtonBar Object not found!");
                return;
            }

            foreach (var component in bbObj.GetComponentsInChildren<Button>())
            {
                switch (component.name)
                {
                    case "Rewind":
                        _rewindButton = component;
                        break;
                    case "Forward":
                        _forwardButton = component;
                        break;
                    case "Pause":
                        _pauseButton = component;
                        break;
                }
            }
        }

        public override void OnLateUpdate()
        {
            // Pause on space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pauseButton.onClick.Invoke();
            }
            
            // If pressed once, rewind 1 turn
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _rewindButton.onClick.Invoke();
            }
            // If kept pressed, rewind fast
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (_rewindFast)
                {
                    _rewindButton.onClick.Invoke();
                }
                else
                {
                    // Trigger fast rewind after 1.5s
                    if (_rewindFastTime == 0)
                    {
                        _rewindFastTime = DateTime.Now.Ticks;
                    }
                    else if (DateTime.Now.Ticks - _rewindFastTime > 1_500_000)
                    {
                        _rewindFast = true;
                        _rewindFastTime = DateTime.Now.Ticks;
                    }
                }
            }
            // Reset fast rewind on release
            else
            {
                _rewindFast = false;
                _rewindFastTime = 0;
            }

            // If pressed once, forward 1 turn
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _forwardButton.onClick.Invoke();
            }
            // If kept pressed, rewind fast
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (_forwardFast)
                {
                    _forwardButton.onClick.Invoke();
                }
                else
                {
                    // Trigger fast rewind after 1.5s
                    if (_forwardFastTime == 0)
                    {
                        _forwardFastTime = DateTime.Now.Ticks;
                    }
                    else if (DateTime.Now.Ticks - _forwardFastTime > 1_500_000)
                    {
                        _forwardFast = true;
                        _forwardFastTime = DateTime.Now.Ticks;
                    }
                }
            }
            // Reset fast rewind on release
            else
            {
                _forwardFast = false;
                _forwardFastTime = 0;
            }
        }
    }
}