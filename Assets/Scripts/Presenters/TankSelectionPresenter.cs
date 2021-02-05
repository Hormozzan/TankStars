using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankSelectionPresenter : MonoBehaviour
{
    public GameObject SpawnP1;
    public GameObject SpawnP2;
    public TanksConfig TanksConfigObj;
    private int SelectedTankP1 = 0;
    private int SelectedTankP2 = 0;
    private bool IsSelectedP1  = false;
    private bool IsSelectedP2  = false;
    public void Start()
    {
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
        SpawnP2.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP2];
    }
    public void NextTankP1()
    {
        SelectedTankP1 = (SelectedTankP1 + 1) % TanksConfigObj.TanksSprites.Length;
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
    }
    public void NextTankP2()
    {
        SelectedTankP2 = (SelectedTankP2 + 1) % TanksConfigObj.TanksSprites.Length;
        SpawnP2.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP2];
    }
    public void PreviousTankP1()
    {
        SelectedTankP1--;
        if (SelectedTankP1 < 0) SelectedTankP1 += TanksConfigObj.TanksSprites.Length;
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
    }
    public void PreviousTankP2()
    {
        SelectedTankP2--;
        if (SelectedTankP2 < 0) SelectedTankP2 += TanksConfigObj.TanksSprites.Length;
        SpawnP2.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP2];
    }
    public void SelectP1()
    {
        PlayerPrefs.SetInt("SelectedTankP1", SelectedTankP1);
        PlayerPrefs.Save();
        IsSelectedP1 = true;
    }
    public void SelectP2()
    {
        PlayerPrefs.SetInt("SelectedTankP2", SelectedTankP2);
        PlayerPrefs.Save();
        IsSelectedP2 = true;
    }
    public void Play()
    {
        if (IsSelectedP1 && IsSelectedP2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
