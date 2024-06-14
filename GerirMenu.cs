using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerirMenu : MonoBehaviour
{
    public void Sair()
    {
        print("Aplicação terminou!");
        Application.Quit();
    }

    public void AbrirJogo()
    {
        SceneManager.LoadScene("Jogar");
    }

    public void AbrirLoja()
    {
        SceneManager.LoadScene("Loja");
    }
    public void AbrirMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MusicaVolume(Slider MV)
    {
        print("Volume da música:" + MV.value);
        RiaDivers.MusicaVolume = MV.value;
    }
    public void FXVolume(Slider FX)
    {
        print("Volume FX:" + FX.value);
        RiaDivers.MusicaVolume = FX.value;
    }

}
