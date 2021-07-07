# **Time-series-visualizer**

Time series visualizer is a flexible extension that provides filling world map by country from `csv` or `json` file.

You can know data value through shades of color 🔥

For example, in the above gif, simulate data from the countries to view the COVID-19 recover cases of the world from real data.
The larger the cases are, the darker the color is

![render_gif](sample/render.gif)

Also provide an simple convert script from csv to json. (Required input format)

# Quickstart

Only support `json` format for the release
Change the variables in [this file](tools/csv2json.py)

```
date_key = "Date column name"
country_key = "Country column name"
value_key = "Value column name"
```
Run command to export to json format

```
$ python csv2json.py --csv <path-to-csv>
```


where:
- `<path-to-csv>`: path to the input csv file

**Example csv**:

| Date     | Country  | Value |
| -------  | -------- | ----- |
| ddmmyyyy | Vietnam  |   x   |

Download lastest build version from [here](https://github.com/nhtlongcs/time-series-visualizer/releases)

Copy `<json-file>` to visualizer data folder

```
./
├─ tools/
│  ├─ input.csv     
├─ release/
│  ├─ visualizer_data/
│  │  ├─ data.json
├─ │  ...
│  ├─ visualizer.exe   
```

Execute `visualizer.exe` to render worldmap

# Special Thanks

I would like to express my gratitude to @nghuycode for his support (Nguyen Gia Huy, APCS2018)
