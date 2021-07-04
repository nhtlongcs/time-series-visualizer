using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using SimpleJSON;

public class Parser : MonoBehaviour
{
    // Start is called before the first frame update
    public string json_path = "";
    public static float maxValue, minValue;
    public static List<KeyValuePair<string, JSONNode>> TimeSeriesList = new List<KeyValuePair<string, JSONNode>>();
    public static JSONObject TimeSeriesData;
    void load()
    {
        string jsonString = File.ReadAllText(json_path);
        TimeSeriesData = (JSONObject)JSON.Parse(jsonString);
        Debug.Log(json_path);
        // Debug.Log(TimeSeriesData["01/01/2021"]["Nicaragua"]);
        List<float> valueCounter = new List<float>();

        foreach (var item in TimeSeriesData)
        {
            TimeSeriesList.Add(item);
            // Debug.Log(item.Key);
            // Debug.Log(item.Value);
            foreach (var country in item.Value)
            {
                valueCounter.Add((float)country.Value);
            }
        }
        maxValue = (float)valueCounter.Max();
        minValue = (float)valueCounter.Min();
    }

    void Awake()
    {
        json_path = Application.dataPath + "/data.json";
        load();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.L)) load();
    }
}
