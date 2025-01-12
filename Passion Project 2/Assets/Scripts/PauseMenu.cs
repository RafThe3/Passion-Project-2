using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private bool muteMusic = false;
    [SerializeField] private AudioSource[] audiosToMute;

    public bool AutoLockCursor { get; set; } = true;

    private AudioSource audioSource;
    private StarterAssetsInputs playerInputs;

    private void Awake()
    {
        if (muteMusic)
        {
            audioSource = Camera.main.GetComponent<AudioSource>();
        }

        playerInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    private void Start()
    {
        pauseMenu.enabled = false;
    }

    private void Update()
    {
        Debug.Log($"Is Pushing Button: {playerInputs.pause}");

        if (playerInputs.pause && Time.timeScale > 0)
        {
            EnablePauseMenu();
        }

        if (AutoLockCursor)
        {
            Cursor.lockState = Time.timeScale == 0 ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    public void EnablePauseMenu()
    {
        pauseMenu.enabled = !pauseMenu.enabled;
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        Cursor.lockState = Time.timeScale == 1 ? CursorLockMode.Locked : CursorLockMode.None;
        if (muteMusic)
        {
            audioSource.Play();
            PlayOtherAudios(true);
            if (!pauseMenu.enabled)
            {
                audioSource.Stop();
                PlayOtherAudios(false);
            }
        }
    }

    private void PlayOtherAudios(bool shouldPlay)
    {
        for (int i = 0; i < audiosToMute.Length; i++)
        {
            if (shouldPlay)
            {
                audiosToMute[i].Pause();
            }
            else
            {
                audiosToMute[i].Play();
            }
        }
    }

    public void Resume()
    {
        playerInputs.pause = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        if (muteMusic)
        {
            audioSource.Stop();
            PlayOtherAudios(false);
        }
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
