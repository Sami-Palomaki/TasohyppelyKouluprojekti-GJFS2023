using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Wait : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start() 
    {
        videoPlayer.loopPointReached += EndReached; // lisää tapahtumankäsittelijä

        videoPlayer.Play(); // käynnistä videon toisto
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(WaitForSceneChange());
    }

    IEnumerator WaitForSceneChange()
    {
        yield return new WaitForSeconds(1f); // odota 2 sekuntia

        SceneManager.LoadScene(2); // vaihda skene
    }
}
