using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    public CanvasGroup uiCanvasGroup;
    public CanvasGroup confirmQuitCanvasGroup;
    public CanvasGroup menuCanvasGroup;
    public CanvasGroup soundCanvasGroup;
    // Use this for initialization
    private void Awake()
    {
        //disable the quit confirmation panel
        DoConfirmQuitNo();
    }


    public void DoConfirmQuitNo()
    {

        //enable the normal ui
        soundCanvasGroup.alpha = 1;
        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;
        menuCanvasGroup.interactable = true;
        soundCanvasGroup.interactable = true;

        //disable the confirmation quit ui
        confirmQuitCanvasGroup.alpha = 0;
        confirmQuitCanvasGroup.interactable = false;
        confirmQuitCanvasGroup.blocksRaycasts = false;
    }

    public void DoConfirmQuitYes()
    {
        Application.Quit();
    }

    public void DoQuit()
    {

        //reduce the visibility of normal UI, and disable all interraction
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.interactable = false;
        soundCanvasGroup.interactable = false;
        soundCanvasGroup.alpha = 0.3f;

        //enable interraction with confirmation gui and make visible
        confirmQuitCanvasGroup.alpha = 1;
        confirmQuitCanvasGroup.interactable = true;
        confirmQuitCanvasGroup.blocksRaycasts = true;
        
    }


}
