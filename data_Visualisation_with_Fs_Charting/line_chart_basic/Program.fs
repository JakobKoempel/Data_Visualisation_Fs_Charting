﻿open FSharp.Charting

let rec factorial (n : int) : int =
    if (n = 0) then 1
    else n * factorial (n - 1)

let combine = Chart.Combine(
                  [
                    Chart.Line [for x in 1..10 -> x * x]
                    Chart.Line [for x in 1..5 -> factorial x]
                    Chart.Line [for x in 1..10 -> x]
                  ])

System.Windows.Forms.Application.Run(combine.ShowChart())