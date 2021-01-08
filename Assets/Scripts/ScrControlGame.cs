using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrControlGame : MonoBehaviour
{

    public static int punts = 0;
    public static int pickupsRestants;

    [SerializeField] GameObject misatgeFi;

    string[] nivells = { "Level1", "Level2", "Level3", "Level4" };
    static int level = 0;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickupsRestants == 0) FiDelJoc();
        ControlEntradaUsuari();
    }

    void FiDelJoc()
    {
         print("LEVEL COMPLETED");
        misatgeFi.SetActive(true);
        Time.timeScale = 0;
    }

    void ControlEntradaUsuari()
    {
        if (Input.GetKeyDown(KeyCode.X)) EliminaPickups();
        if (Input.GetKeyDown(KeyCode.Return) && pickupsRestants == 0) NextLevel();
    }

    void EliminaPickups()
    {
        // pickupsRestants = 0;
        GameObject[] picks;
        picks = GameObject.FindGameObjectsWithTag("pickup");
        foreach (GameObject p in picks)
        {

            punts += p.GetComponent<ScrPickup>().valor;
            Destroy(p);
            pickupsRestants--;
        }
    }
    void EliminaPickups2()
    {
        // pickupsRestants = 0;
        GameObject[] badpicks;
        badpicks = GameObject.FindGameObjectsWithTag("badpickup");
        foreach (GameObject p in badpicks)
        {

            punts -= p.GetComponent<ScrPickup>().valor;
            Destroy(p);
        }
    }

    void NextLevel()
    {
        level++;
        if (level < nivells.Length)
            SceneManager.LoadScene(nivells[level]);
        else GameOver();
    }

    void GameOver()
    {
        print("GameOver!");
    }
}
