using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    private static State currentState = State.PlayingFPS;

    public static State GetState()
    {
        return currentState;
    }

    static void SetState(State newState)
    {
        currentState = newState;
    }

    public static bool IsPlayingFPS()
    {
        if (currentState == State.PlayingFPS)
            return true;

        return false;
    }

    public static bool IsInteracting()
    {
        if (currentState == State.Interacting)
            return true;

        return false;
    }

    public static void SwitchToInteracting()
    {
        MouseLocker.FreeMouse();
        SetState(State.Interacting);
    }

    public static void SwitchToPlayingFPS()
    {
        MouseLocker.LockMouse();
        SetState(State.PlayingFPS);
    }
}

public enum State 
{
    OnCutscene,
    PlayingFPS, 
    Interacting
}
