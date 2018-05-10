open FSharp.Charting

let electionResults = 
    [ "CDU/CSU", 33.; 
      "SPD", 20.5; 
      "AfD", 12.6; 
      "FDP", 10.7; 
      "Linke", 9.2; 
      "Grünen", 8.9
      "Sonstige", 5.]

let chart = Chart.Pie electionResults

System.Windows.Forms.Application.Run(chart.ShowChart())