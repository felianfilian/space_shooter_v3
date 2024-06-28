using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject failScreen;


    void Start()
    {
        
    }

    public void ActivateWin()
    {
        winScreen.SetActive(true);
    }

    public void ActivateFail()
    {
        failScreen.SetActive(true);
    }
}
