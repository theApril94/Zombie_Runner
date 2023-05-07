using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;

    private void Start()
    {
        GameOverCanvas.enabled = false;
    }

    public void HandlerDeath()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0; //zatrzymuje grê
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None; //chowa kursor kiedy player umiera
        Cursor.visible = true; //widzimy kursor
        GetComponent<FirstPersonController>().enabled = false;
    }

}
