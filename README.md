# **Time-series-visualizer**

Repo phục vụ việc hiển thị bản đồ heatmap từ dữ liệu timeseries
Hỗ trợ định dạng `json` / `csv` 

# Quickstart
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
