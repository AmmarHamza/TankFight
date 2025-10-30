using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour
{
    //Declare the arrays to store the 10 names and scores as TMP text fields
    public TMP_Text[] nameFields;
    public TMP_Text[] scoreFields;
    int[] scores = new int[10];
    //Declare the TMP input field to take the user's name
    public TMP_InputField nameInput;

    //Declare a string to store the path of the save file
    private string savePath;

    //Declare a method to initialize all the fields to be empty
    private void Start()
    {
        //Loop through the 10 name and score fields
        for (int i = 0; i < 10; i++)
        {
            //Set the name and score fields to empty strings
            nameFields[i].SetText("");
            scoreFields[i].text = scores[i].ToString();
        }

        //Set the save path to be in the persistent data path of the application
        savePath = Application.persistentDataPath + "/leaderboard.json";

        //Load the leaderboard data if it exists
        LoadLeaderboard();
    }

    //Declare a method to create the leaderboard
    public void CreateLeaderboard()
    {
        //Get the user's name from the input field
        string userName = nameInput.text;

        //Get the user's score from the Score class
        int userScore = Score.score;

        //Loop through the 10 name and score fields
        for (int i = 0; i < 10; i++)
        {
            //Get the current name and score from the fields
            string currentName = nameFields[i].text;
            int currentScore = scores[i];

            //Compare the user's score with the current score
            if (userScore > currentScore)
            {
                //If the user's score is higher, insert the user's name and score at this position
                //and shift the rest of the names and scores down by one
                for (int j = 9; j > i; j--)
                {
                    nameFields[j].SetText(nameFields[j - 1].text);
                    scoreFields[j].SetText(scoreFields[j - 1].text);
                    scores[j] = scores[j - 1]; //Update the scores array as well
                }
                nameFields[i].SetText(userName);
                scoreFields[i].SetText(userScore.ToString());
                scores[i] = userScore; //Update the scores array as well
                break; //Exit the loop after inserting the user's name and score
            }
        }
    }

    //Declare a method to save the leaderboard data as JSON
    public void SaveLeaderboard()
    {
        Score.Save();
        //Create a new list of characters from the name and score fields
        List<Character> characters = new List<Character>();
        for (int i = 0; i < 10; i++)
        {
            characters.Add(new Character(nameFields[i].text, scores[i]));
        }

        //Create a new PartyData object with an array of characters
        PartyData data = new PartyData(characters);

        //Convert the PartyData object to JSON string using JsonUtility
        string json = JsonUtility.ToJson(data);

        //Write the JSON string to a file using StreamWriter
        using (StreamWriter writer = new StreamWriter(savePath))
        {
            writer.Write(json);
        }
    }

    //Declare a method to load the leaderboard data from JSON
    public void LoadLeaderboard()
    {
        //Check if the save file exists
        if (File.Exists(savePath))
        {
            //Read the JSON string from a file using StreamReader
            using (StreamReader reader = new StreamReader(savePath))
            {
                string json = reader.ReadToEnd();

                //Convert the JSON string to PartyData object using JsonUtility
                PartyData data = JsonUtility.FromJson<PartyData>(json);

                //Loop through the 10 name and score fields
                for (int i = 0; i < 10; i++)
                {
                    //Set the name and score fields to the values from the PartyData object
                    nameFields[i].SetText(data.characters[i].name);
                    scoreFields[i].SetText(data.characters[i].score.ToString());
                    scores[i] = data.characters[i].score; //Update the scores array as well
                }
            }
        }
    }

    //Declare a method to handle the application quit event
    private void OnApplicationQuit()
    {
        //Save the leaderboard data before quitting
        SaveLeaderboard();
    }

    //Declare a method to handle the application focus event
    private void OnApplicationFocus(bool hasFocus)
    {
        //If the application loses focus, save the leaderboard data
        if (!hasFocus)
        {
            SaveLeaderboard();
        }
        //If the application gains focus, load the leaderboard data
        else
        {
            LoadLeaderboard();
        }
    }
}

//Declare a class to store the character data
[System.Serializable]
public class Character
{
    public string name;
    public int score;

    //Declare a constructor to initialize the name and score
    public Character(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

//Declare a class to store the party data as an array of characters
[System.Serializable]
public class PartyData
{
    public Character[] characters;

    //Declare a constructor to initialize the characters array from a list of characters
    public PartyData(List<Character> characters)
    {
        this.characters = characters.ToArray();
    }
}