open FSharp.Charting

let tupleSeqToLineChart (s : (float * float) seq) : ChartTypes.GenericChart =
    Chart.Line ([for i in 0 .. (Seq.length s) - 1 -> fst (Seq.item i s), snd (Seq.item i s) ])

let tupleSeqToPointChart (s : (float * float) seq) : ChartTypes.GenericChart =
    Chart.Point ([for i in 0 .. (Seq.length s) - 1 -> fst <| Seq.item i s , snd <| Seq.item i s])

let data : (float * float) list = [(5.0 , 8.0) ; (1.0 , 6.5) ; (10.0 , 17.3) ; (6.0 , 11.2)]

let chart = Chart.Combine (
               [ tupleSeqToLineChart <| Seq.sortBy (fun (x, _) -> x) data
                 tupleSeqToPointChart data]
            )
System.Windows.Forms.Application.Run(chart.ShowChart())