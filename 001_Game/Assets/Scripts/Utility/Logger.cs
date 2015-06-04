using UnityEngine;
using System.Collections;
using System.IO;

/**
 * Author:  Ingo Mayer
 * Date:    25.03.2015 
 * 
 * Last modified: 27.05.2015 - Ingo Mayer
 * 
 * Purpose: Logging class for use in BlackBox Productions projects.
 *          Provides a number of different logging functions (warning, error, info, etc.) that will be logged in an HTML file for better visualization.
 *          The log level determines how much will be logged (to improve performance for more developed versions of the project).
 *          Log Level: 0 - complete | 1 - important debug info | 2 - release
**/


// ToDo: add log level functionality
public class Logger : MonoBehaviour
{
    // singleton
    static Logger instance = null;

    // ToDo: move to config or make constant
    private int logLevel_ = 0;
    private string logDirectory_ = Application.dataPath + "/../bin/log.html";

    // color coding
    const string infoColor      = "#87CEEB";    // light blue
    const string warningColor   = "#FFD700";    // yellow
    const string errorColor     = "#CD0000";    // red
    const string inputColor     = "#66CDAA";    // light green
    const string guiColor       = "#9932CC";    // purple
    const string audioColor     = "#FFBBFF";    // pink
    const string networkColor   = "#8B5A2B";    // brown
    const string gamelogicColor = "#0A2A22";    // dark green
    const string aiColor        = "#27408B";    // dark blue
    const string physicsColor   = "#FF7F00";    // orange

    // log entry types
    private enum entryType
    {               
        INIT,        
        INFO,
        WARNING,
        ERROR,
        INPUT,
        GUI,
        AUDIO,
        NETWORK,
        GAMELOGIC,
        AI,
        PHYSICS
    }

    /**
    * Purpose: Init logger with first entry (gamename & date)
    **/   
    protected Logger() { }

    static public bool isActive
    {
        get
        {
            return instance != null;
        }
    }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Object.FindObjectOfType(typeof(Logger)) as Logger;

                if (instance == null)
                {
                    // Create new game object for the manager
                    GameObject gameObj = new GameObject("logger");
                    DontDestroyOnLoad(gameObj);
                    instance = gameObj.AddComponent<Logger>();
                    
                }
            }

            return instance;
        }
    }


    /**
    * The following functions all follow the same principle, they are just wrapper functions to
    * keep the actual file writing private
    **/   
    private void init()
    {
        writeToFile(entryType.INIT, Application.productName);
    }

    public void info(string logEntry)
    {
        writeToFile(entryType.INFO, logEntry);
    }

    public void warning(string logEntry)
    {
        writeToFile(entryType.WARNING, logEntry);
    }

    public void error(string logEntry)
    {
        writeToFile(entryType.ERROR, logEntry);
    }

    public void input(string logEntry)
    {
        writeToFile(entryType.INPUT, logEntry);
    }

    public void gui(string logEntry)
    {
        writeToFile(entryType.GUI, logEntry);
    }

    public void audio(string logEntry)
    {
        writeToFile(entryType.AUDIO, logEntry);
    }

    public void network(string logEntry)
    {
        writeToFile(entryType.NETWORK, logEntry);
    }

    public void gamelogic(string logEntry)
    {
        writeToFile(entryType.GAMELOGIC, logEntry);
    }

    public void ai(string logEntry)
    {
        writeToFile(entryType.AI, logEntry);
    }

    public void physics(string logEntry)
    {
        writeToFile(entryType.PHYSICS, logEntry);
    }
         
    /**
    * Purpose: Actual file write function used internally in this class
    **/   
    private void writeToFile(entryType logEntryType, string logEntry)
    {
        // used to build complete log entry
        string completeEntry = "";

        // check for empty string
        if (logEntry.Length <= 0)
            return;

        //  log cases -> build log string for each case
        switch(logEntryType)
        {
            case entryType.INIT:
                // delete last log, only done for first entry of new log
                File.Delete(logDirectory_);

                // first entry includes CSS styles for color coding the entries
                completeEntry = "<style>\n"
                              + "p.info {background: " + infoColor + "; color: white;}\n"
                              + "p.warning {background: " + warningColor + "; color: white;}\n"
                              + "p.error {background: " + errorColor + "; color: white;}\n"
                              + "p.input {background: " + inputColor + "; color: white;}\n"
                              + "p.gui {background: " + guiColor + "; color: white;}\n"
                              + "p.audio {background: " + audioColor + "; color: white;}\n"
                              + "p.network {background: " + networkColor + "; color: white;}\n"
                              + "p.gamelogic {background: " + gamelogicColor + "; color: white;}\n"
                              + "p.ai {background: " + aiColor + "; color: white;}\n"
                              + "p.physics {background: " + physicsColor + "; color: white;}\n"
                              + "</style>\n"
                              + "<h3>" + System.DateTime.Now + " | " + logEntry + "</h1>\n";
                break;

            case entryType.INFO:
                completeEntry = "<p class=\"info\">";
                break;
                 
            case entryType.WARNING:
                completeEntry = "<p class=\"warning\">";
                break;

            case entryType.ERROR:
                completeEntry = "<p class=\"error\">";
                break;

            case entryType.INPUT:
                completeEntry = "<p class=\"input\">";
                break;

            case entryType.GUI:
                completeEntry = "<p class=\"gui\">";
                break;

            case entryType.AUDIO:
                completeEntry = "<p class=\"audio\">";
                break;

            case entryType.NETWORK:
                completeEntry = "<p class=\"network\">";
                break;

            case entryType.GAMELOGIC:
                completeEntry = "<p class=\"gamelogic\">";
                break;

            case entryType.AI:
                completeEntry = "<p class=\"ai\">";
                break;

            case entryType.PHYSICS:
                completeEntry = "<p class=\"physics\">";
                break;

            default:
                return;
         }

        // add the part that is the same for all cases
        completeEntry += System.DateTime.Now + " | " + logEntry + "</p>\n";

        // append log string to file, if it does not exist -> create it
        File.AppendAllText(logDirectory_, completeEntry);
    }

}