open FSharp.Charting

let countryData1 = 
    [ "Africa", 1_126_396_209L; 
      "Asia", 4_436_285_301L; 
      "Europe", 741_461_395L; 
      "South America", 425_849_627L; 
      "North America", 579_461_659L; 
      "Australia \nOceania", 25_305_783L]

let countryData2 =
    [ "Antarctica", 2000L]

let chart = Chart.Bar (countryData1 @ countryData2 |> Seq.sortByDescending (fun (_, y) -> y), Name = "Population by Continent")

System.Windows.Forms.Application.Run(chart.ShowChart())