using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // Fungsi untuk memulai perpindahan scene
    public void PindahKeSceneTujuan(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}