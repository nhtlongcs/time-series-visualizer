from datetime import date
from tqdm import tqdm
import pandas as pd
import json
import argparse

"""
Convert csv to json for visualing unity 3d
"""
parser = argparse.ArgumentParser(description="Process some integers.")
parser.add_argument(
    "--csv_in", type=str, default="./covid19.csv", help="input csv path"
)
parser.add_argument(
    "--json_out", type=str, default="./covid19.json", help="output json path "
)

date_key = "ObservationDate"
country_key = "Country/Region"
value_key = "Deaths"


def df2dict(
    data: pd.DataFrame,
    date_key: str = "ObservationDate",
    country_key: str = "Country/Region",
    value_key: str = "Deaths",
) -> dict:
    """
        Args: 
            + input dataframe have the format | datekey | countrykey | valuekey |
        Output:
            + dictionary have format { date: { country : value } }
    """
    df = data.copy()

    res = {}
    for x in tqdm(df[date_key].unique()):
        indaydf = df[df[date_key] == x]
        res[x] = {}
        for y in indaydf[country_key].unique():
            res[x][y] = indaydf[indaydf[country_key] == y][value_key].values[0]
    return res


if __name__ == "__main__":
    args = parser.parse_args()
    df = pd.read_csv(args.csv_in)

    df = df[[date_key, country_key, value_key]]
    df = df.groupby([date_key, country_key])[value_key].sum().reset_index()
    df = df.drop_duplicates()
    df = df.sort_values(by=[date_key]).reset_index(drop=True)

    df[value_key] = [float(x) for x in range(len(df))]  # dummy data generate
    df.to_csv("meta.csv", index=False)
    json_data = df2dict(df)
    with open(args.json_out, "w") as outfile:
        json.dump(json_data, outfile)

