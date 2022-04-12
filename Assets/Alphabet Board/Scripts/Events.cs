using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// Implement your game events in this script
public class Events : MonoBehaviour
{
    private WritingHandler writingHandler;
    private Buton btton;
    public static bool clicked;
    string sceneName;
    private void Awake()
    {
        Application.logMessageReceived += HandleException;

    }
    void Start()
    {
        //Setting up the writingHandler reference
        GameObject letters = GameObject.Find("Letters");
        if (letters != null)
        {
            writingHandler = letters.GetComponent<WritingHandler>();
        }
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;


    }
    private void Update()
    {

    }
    private string m_Writer;
    private int m_ExceptionCount = 0;
    private void HandleException(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Exception)
        {
            m_ExceptionCount++;
            m_Writer = string.Format("{0}: {1}\n{2}", type, condition, stackTrace);
            // Firebase.Analytics.FirebaseAnalytics.LogEvent("Exception", m_Writer, "");
            Debug.Log("Exception! ");
        }
    }
    //Load the next letter
    public void LoadTheNextLetter(object ob)
    {
        if (writingHandler == null)
        {
            return;
        }

        writingHandler.LoadNextLetter();
        clicked = true;
        Debug.Log(clicked);
    }

    //Load the previous letter
    public void LoadThePreviousLetter(object ob)
    {
        if (writingHandler == null)
        {
            return;
        }
        writingHandler.LoadPreviousLetter();

    }

    //Load the current letter
    public void LoadLetter(Object ob)
    {
        if (ob == null)
        {
            return;
        }
        WritingHandler.currentLetterIndex = int.Parse(ob.name.Split('-')[1]);
        SceneManager.LoadScene("AlphabetWriting");
   
        try
        {
            writingHandler.LoadNextHint();
        }
        catch (System.Exception)
        {

        }
    }
    public void LoadArabicLetter(Object ob)
    {
        if (ob == null)
        {
            return;
        }
        WritingHandler.currentLetterIndex = int.Parse(ob.name.Split('-')[1]);
        SceneManager.LoadScene("Arabic");
     
        try
        {
            writingHandler.LoadNextHint();
        }
        catch (System.Exception)
        {

        }

    }
    public void LoadArabicNumber(Object ob)
    {
        if (ob == null)
        {
            return;
        }
        WritingHandler.currentLetterIndex = int.Parse(ob.name.Split('-')[1]);
        SceneManager.LoadScene("ArabicNumbers");
    
        try
        {
            writingHandler.LoadNextHint();
        }
        catch (System.Exception)
        {

        }

    }
    public void LoadEnglishNumber(Object ob)
    {
        if (ob == null)
        {
            return;
        }
        WritingHandler.currentLetterIndex = int.Parse(ob.name.Split('-')[1]);
        SceneManager.LoadScene("EnglishNumbers");
     
        try
        {
            writingHandler.LoadNextHint();
        }
        catch (System.Exception)
        {

        }

    }


    //Erase the current letter
    public void EraseLetter(Object ob)
    {
        if (writingHandler == null)
        {
            return;
        }
        writingHandler.RefreshProcess();

    }

    //Load alphabet menu
    public void LoadAlphabetMenu(Object ob)
    {
        SceneManager.LoadScene("MainMenu");
        WritingHandler.currentHintIndex = 0;
        WritingHandler.currentLetterHintIndex = 0;

    }

    public void CloseGame(Object ob)
    {
        try
        {
            if (sceneName == "A" || sceneName == "Menu")
            {
                //SceneManager.UnloadScene("Menu");
                SceneManager.LoadSceneAsync("MainMenu");
            }
            // MainMenuManager.MainMenuLoaded = true;

        }
        catch (System.Exception)
        {
            throw;
        }
        // Application.Quit();
        // Debug.Log("Quited");
    }

}
