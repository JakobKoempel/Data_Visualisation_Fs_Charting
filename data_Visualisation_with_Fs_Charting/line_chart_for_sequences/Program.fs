open FSharp.Charting

let seqToLineChart (s : int seq) : ChartTypes.GenericChart =
    Chart.Line([for x in 0 .. (Seq.length s) - 1 -> Seq.item x s])

let seqToPointChart (s : int seq) : ChartTypes.GenericChart =
    Chart.Point ([for x in 0 .. (Seq.length s) - 1 -> Seq.item x s])

let data : int list = [1; 5; -4; 0; 2]

let combinedChart = Chart.Combine(
                       [ seqToLineChart data
                         seqToPointChart data])

System.Windows.Forms.Application.Run(combinedChart.ShowChart())