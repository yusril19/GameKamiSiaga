using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMe : MonoBehaviour
{
    public CanvasGroup AboutMeUI;
    public CanvasGroup MenuGroup;
    public CanvasGroup ExitGroup;
    public CanvasGroup SoundGroup;

    private void Awake()
    {
        AboutMeOff();
    }
    public void AboutMeOff()
    {

        MenuGroup.interactable = true;
        ExitGroup.interactable = true;
        SoundGroup.interactable = true;
        SoundGroup.alpha = 1;

        AboutMeUI.interactable = false;
        AboutMeUI.alpha = 0;
        AboutMeUI.blocksRaycasts = false;
    }
    public void AboutMeOn()
    {
        MenuGroup.interactable = false;
        ExitGroup.interactable = false;
        SoundGroup.interactable = false;
        SoundGroup.alpha = 0.3f;

        AboutMeUI.blocksRaycasts = true;
        AboutMeUI.interactable = true;
        AboutMeUI.alpha = 1;
    }
}
