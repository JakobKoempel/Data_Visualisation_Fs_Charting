open FSharp.Charting

let countryData = 
    [ "Afrika", 1_126_396_209L; 
      "Asien", 4_436_285_301L; 
      "Europa", 741_461_395L; 
      "Süd Amerika", 425_849_627L; 
      "Nord Amerika", 579_461_659L; 
      "Australia", 25_305_783L]

let chart = countryData |> List.sortBy (fun (_, y) -> y) |> Chart.Pie

System.Windows.Forms.Application.Run(chart.ShowChart())