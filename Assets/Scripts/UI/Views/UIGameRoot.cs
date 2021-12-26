﻿using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField]
    private UIGameView gameView;
    public UIGameView GameView => gameView;

    public override void ShowRoot()
    {
        base.ShowRoot();

        gameView.ShowView();
    }

    public override void HideRoot()
    {
        gameView.HideView();

        base.HideRoot();
    }
}
