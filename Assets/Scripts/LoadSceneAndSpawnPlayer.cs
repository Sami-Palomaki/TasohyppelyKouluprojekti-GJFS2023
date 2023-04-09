using UnityEngine; // sisältää Unityn peruskomponentit ja toiminnallisuudet
using System.Collections; // sisältää kokoelman perusluokat, kuten IEnumerator ja IEnumerable
using UnityEngine.SceneManagement; // sisältää Scene Manager -toiminnallisuudet


public class LoadSceneAndSpawnPlayer : MonoBehaviour
{
    public string sceneName; // kohtauksen nimi
    public GameObject playerPrefab; // pelaajan prefab
    public Vector3 spawnPosition; // paikka, johon pelaaja ilmestyy

    void Start()
    {
        SceneManager.LoadScene(sceneName); // ladataan kohtaus
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // rekisteröidään sceneLoaded-tapahtumankäsittelijä
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // poistetaan sceneLoaded-tapahtumankäsittelijä
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity); // luodaan pelaaja prefabista ja asetetaan paikka
    }
}
