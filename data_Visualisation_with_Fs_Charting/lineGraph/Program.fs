open FSharp.Charting

let rec factorial (n : int) : int =
    if (n = 0) then 1
    else n * factorial (n - 1)

let lineChart1 = 
let lineChart2 = Chart.Line ([for x in 1..5 -> x, factorial x], Name = "factorial function")
let lineChart3 = Chart.Line ([for x in 1..10 -> x , x], Name = "linear function")

let combine = Chart.Combine([
                    Chart.Line ([for x in 1..10 -> x , x * x], Name = "quadradic function") ; lineChart2
                    lineChart3])

System.Windows.Forms.Application.Run(combine.ShowChart())
