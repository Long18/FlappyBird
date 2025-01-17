using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GUIDeath : MonoBehaviour
{
    [Header("Raise Event")] [SerializeField]
    private LoadEventChannelSO loadSceneEventChannel;

    [SerializeField] private BoolEventChannel onRestartEventChannel;
    [SerializeField] private BoolEventChannel onWelcomeEventChannel;

    [Header("Other")] [SerializeField] private GameSceneSO titleSceneSO;
    [SerializeField] private GameObject panel;

    private void OnEnable()
    {
        onRestartEventChannel.OnEventRaised += OnActiveGUI;
    }

    private void OnDisable()
    {
        onRestartEventChannel.OnEventRaised -= OnActiveGUI;
    }

    private void OnActiveGUI(bool active)
    {
        panel.SetActive(active);
    }

    public void OnRestart()
    {
        GameStateManager.GameState = GameState.Intro;
        loadSceneEventChannel.RequestLoadScene(titleSceneSO);
        onWelcomeEventChannel.RaiseEvent(true);
        OnActiveGUI(false);
    }
}