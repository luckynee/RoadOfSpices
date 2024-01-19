using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // SerializeField digunakan agar fungsi tetap dapat diakses dari Inspector
    [SerializeField]
    private string sceneTujuan;

    // Fungsi untuk memulai perpindahan scene
    private void PindahKeSceneTujuan()
    {
        SceneManager.LoadScene(sceneTujuan);
    }

    // Fungsi untuk memulai perpindahan scene
    //public void PindahKeSceneTujuan(string SampleScene)
    //{
        //SceneManager.LoadScene(SampleScene);
    //}
}