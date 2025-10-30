using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    public static void Save()
    {
        // Create a new object to store the score
        ScoreData data = new ScoreData();
        data.score = score;

        // Convert the object to a json string
        string json = JsonUtility.ToJson(data);

        // Get the path of the json file
        string path = Application.persistentDataPath + "/score.json";

        // Write the json string to the file
        File.WriteAllText(path, json);
    }

    // A static function to load the score from a json file
    public static void Load()
    {
        // Get the path of the json file
        string path = Application.persistentDataPath + "/score.json";

        // Check if the file exists
        if (File.Exists(path))
        {
            // Read the json string from the file
            string json = File.ReadAllText(path);

            // Convert the json string to an object
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            // Assign the score from the object
            score = data.score;
        }
        else
        {
            // Set the score to zero if the file does not exist
            score = 0;
        }
    }
    [System.Serializable]
    public class ScoreData
    {
        public int score;
    }
}
