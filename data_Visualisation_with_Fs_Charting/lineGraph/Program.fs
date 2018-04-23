open FSharp.Charting

let lineChart = Chart.Line [for x in 1..10 -> x , x * x]

System.Windows.Forms.Application.Run(lineChart.ShowChart())
