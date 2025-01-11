using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEditor.Profiling;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool lockCursor = false;
    private int fps = 0;
    private int fpsMode = 0;

    private void Start()
    {
        Time.timeScale = 1;

        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void LoadAScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadAScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void EnableCanvas(Canvas canvas)
    {
        canvas.enabled = true;
    }

    public void DisableCanvas(Canvas canvas)
    {
        canvas.enabled = false;
    }

    public void ChangeScreenMode(TMP_Dropdown dropdown)
    {
        int screenMode = dropdown.value;
        FullScreenMode mode = new();

        switch (screenMode)
        {
            case 0:
                mode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                mode = FullScreenMode.FullScreenWindow;
                break;

            case 2:
                mode = FullScreenMode.MaximizedWindow;
                break;

            case 3:
                mode = FullScreenMode.Windowed;
                break;

            default:
                break;
        }

        Debug.Log(mode);
        Screen.fullScreenMode = mode;
    }

    public void PlaySFX(AudioClip audioClip)
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    public void ChangeMaxFPS(TextMeshProUGUI fpsText)
    {
        fpsText.text = $"{fps} FPS";
        Application.targetFrameRate = fps;
    }

    public void MaxFPS(int increment)
    {
        fpsMode += increment;

        if (fpsMode == 1)
        {
            fps = 30;
        }
        else if (fpsMode == 2)
        {
            fps = 60;
        }
        else if (fpsMode == 3)
        {
            fps = 120;
        }
        else if (fpsMode == 4)
        {
            fps = 144;
        }
        else if (fpsMode == 5)
        {
            fps = 165;
        }
        else if (fpsMode == 6)
        {
            fps= 180;
        }
        else if (fpsMode == 7)
        {
            fps = 200;
        }
        else if (fpsMode == 8)
        {
            fps = 240;
        }
        else if (fpsMode == 9)
        {
            fps = 360;
        }
        else
        {
            fps = 0;
        }

        if (fpsMode > 9)
        {
            fpsMode = 9;
        }

        if (fpsMode < 0)
        {
            fpsMode = 0;
        }
    }


    /*
    public void SavePlayerProgress()
    {
        GameObject.FindWithTag("Player").GetComponent<SaveSystem>().Save();
    }

    public void LoadPlayerProgress()
    {
        GameObject.FindWithTag("Player").GetComponent<SaveSystem>().Load();
    }

    public void DeletePlayerProgress()
    {
        GameObject.FindWithTag("Player").GetComponent<SaveSystem>().Delete();
    }
    */
}
