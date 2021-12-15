using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject portal;

    [SerializeField]
    Text gems;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    Text status;

    int gemsCount;
    bool keyFound;

    public void IncreaseGems(int quantity)
    {
        gemsCount += quantity;
        gems.text = "Secretos: " + gemsCount.ToString() + "de 17";
    }

    public void KeyFound()
    {
        keyFound = true;
        portal.SetActive(true);
    }

    public void Lose()
    {
        Invoke(nameof(ReloadScene), 3.0F);
        Status("HAS PERDIDO");
    }

    public void Win()
    {
        Time.timeScale = 0.0F;
        Status("HAS GANADO");
    }

    void Status(string text)
    {
        status.text = text;
        panel.SetActive(true);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DoSomething(bool b)
    {
        //do something
    }

    public void Attack(bool b)
    {
        //attack!
    }
}