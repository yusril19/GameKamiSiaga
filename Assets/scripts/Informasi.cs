using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informasi : MonoBehaviour
{
    public CanvasGroup BackUi;
    public CanvasGroup MenuUi;
    public CanvasGroup InformasiUi;
    public CanvasGroup Tas;
    public CanvasGroup quiz;

    private void Awake()
    {
        informasiOff();
    }
    public void informasiOff()
    {
        BackUi.interactable = true;
        MenuUi.interactable = true;
        InformasiUi.interactable = true;

        Tas.interactable = false;
        quiz.interactable = false;
        Tas.alpha = 0;
        quiz.alpha = 0;
    }
    public void infromasiON()
    {
        BackUi.interactable = false;
        MenuUi.interactable = false;
        InformasiUi.interactable = false;

        Tas.interactable = true;
        quiz.interactable = true;
        Tas.alpha = 1;
        quiz.alpha = 1;
    }
}
