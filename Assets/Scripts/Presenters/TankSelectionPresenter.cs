using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TankSelectionPresenter : MonoBehaviour
{
    public GameObject SpawnP1;
    public GameObject SpawnP2;
    public TanksConfig TanksConfigObj;
    public Text P1TankNameText;
    public Text P2TankNameText;
    private int SelectedTankP1 = 0;
    private int SelectedTankP2 = 0;
    private bool IsSelectedP1  = false;
    private bool IsSelectedP2  = false;
    private string[] TanksName = { "Abrams", "Coalition", "Frost", "Mark" };
    
    
    public void Start()
    {
        P1TankNameText.text = TanksName[SelectedTankP1];
        P2TankNameText.text = TanksName[SelectedTankP2];
    
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
        SpawnP2.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP2];
    }
    
    
    public void NextTankP1()
    {
        SelectedTankP1 = (SelectedTankP1 + 1) % TanksConfigObj.TanksSprites.Length;
        P1TankNameText.text = TanksName[SelectedTankP1];
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
    }
    
    
    public void NextTankP2()
    {
        SelectedTankP2 = (SelectedTankP2 + 1) % TanksConfigObj.TanksSprites.Length;
        P2TankNameText.text = TanksName[SelectedTankP2];
        SpawnP2.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP2];
    }
    
    
    public void PreviousTankP1()
    {
        SelectedTankP1--;
        if (SelectedTankP1 < 0) SelectedTankP1 += TanksConfigObj.TanksSprites.Length;
        P1TankNameText.text = TanksName[SelectedTankP1];
        SpawnP1.GetComponent<SpriteRenderer>().sprite = TanksConfigObj.TanksSprites[SelectedTankP1];
    }
    
    
    public void PreviousTankP2()
    {
        SelectedTankP2--;
        if (SelectedTankP2 < 0) SelectedTankP2 += TanksConfigObj.TanksSprites.Length;
        P2TankNameText.text = TanksName[SelectedTankP2];
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
        if (!IsSelectedP1)
        {
            SelectP1();
        }
    
        if (!IsSelectedP2)
        {
            SelectP2();
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
