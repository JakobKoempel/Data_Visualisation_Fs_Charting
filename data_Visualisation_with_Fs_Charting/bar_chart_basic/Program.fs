open FSharp.Charting

let countryData = 
    [ "Africa", 1_126_396_209L; 
      "Asia", 4_436_285_301L; 
      "Europe", 741_461_395L; 
      "South America", 425_849_627L; 
      "North America", 579_461_659L; 
      "Australia \nOceania", 25_305_783L]

let sortedData = Seq.sortBy (fun (_, i) -> i) countryData

let chart = Chart.Bar (Seq.sortBy (fun (_, i) -> i) countryData)
System.Windows.Forms.Application.Run(chart.ShowChart())
