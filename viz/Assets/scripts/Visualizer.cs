using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using WPMF;
using UnityEngine.UI;
public class Visualizer : MonoBehaviour
{
    // Start is called before the first frame update

    WorldMap2D map;
    JSONObject jsondata = Parser.TimeSeriesData;

    public Color colorValueCustom;
    public Text DateText;
    public Slider GlobalSlider;
    void Start()
    {
        map = WorldMap2D.instance;
        GlobalSlider.value = 0f;
        map.enableCountryHighlight = false;
        StartCoroutine(x());
    }
    // Update is called once per frame
    int getday()
    {
        float day = GlobalSlider.value;
        int index = (int)(day * Parser.TimeSeriesList.Count);
        index = index < 0 ? 0 : index;
        index = Parser.TimeSeriesList.Count - 1 < index ? Parser.TimeSeriesList.Count - 1 : index;
        DateText.text = Parser.TimeSeriesList[index].Key;
        Debug.Log(Parser.TimeSeriesList[index].Key);
        return index;
    }

    IEnumerator x()
    {
        while (true)
        {

            GlobalSlider.value += 0.001f;
            int instant_day = getday();
            foreach (var country in Parser.TimeSeriesList[instant_day].Value)
            {
                float vizValue = country.Value;
                float maxValue = Parser.maxValue;
                float minValue = Parser.minValue;
                float vizValueNormalize = (vizValue - minValue) / (maxValue - minValue); // standard normalization
                colorize(country.Key, vizValueNormalize);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
    void colorize(string countryName, float colorValueFloat)
    {
        float lowerBoundColor = 0.1f;
        float upperBoundColor = 1f;
        float scaleValue = colorValueFloat * (upperBoundColor - lowerBoundColor) + lowerBoundColor;
        Color colorValue = new Color(colorValueFloat, 0, 0, 1);
        int countryID = WorldMap2D.instance.GetCountryIndex(countryName);
        WorldMap2D.instance.ToggleCountrySurface(countryID, true, colorValue);
    }
}
