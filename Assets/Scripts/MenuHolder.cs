using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHolder : MonoBehaviour
{
    [SerializeField] private Transform menu;
    [SerializeField] private Transform credit;
    [SerializeField] private Transform level;

    private void Start()
    {
        menu.gameObject.SetActive(true);
        credit.gameObject.SetActive(false);
        level.gameObject.SetActive(false);
    }

    public void ActiveUI(string s)
    {
        menu.gameObject.SetActive(false);
        credit.gameObject.SetActive(false);
        level.gameObject.SetActive(false);
        switch (s)
        {
            case "menu":
                menu.gameObject.SetActive(true);
                break;
            case "credit":
                credit.gameObject.SetActive(true);
                break;
            case "level":
                level.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void GoToLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void Exit()
    {
        Application.Quit(0);
    }

}
