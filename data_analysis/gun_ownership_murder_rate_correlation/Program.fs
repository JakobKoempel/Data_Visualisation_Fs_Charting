open System.IO
open FSharp.Charting

let countryData = File.ReadAllLines "gun_ownership_and_homocide_rate.txt"
                  |> Seq.map (fun s -> s.Split [|' '|] )
                  |> Seq.map (fun array -> (float array.[Seq.length array - 2], float array.[Seq.length array - 3]))

let SLR (s : (float * float) seq) : float -> float =
    let xSeq = Seq.map (fun (x, _) -> x) s
    let xMean = Seq.average xSeq
    let xDif = Seq.map (fun i -> i - xMean) xSeq
    let xDifSquaredSum = Seq.sumBy (fun i -> i ** 2.0) xDif
    let ySeq = Seq.map (fun (_, y) -> y) s
    let yMean = Seq.average ySeq
    let xDifTimesyDifSum = Seq.map2 (fun x y -> x * (y - yMean)) xDif ySeq |> Seq.sum

    let m = xDifTimesyDifSum / xDifSquaredSum
    let n = yMean - xMean * m
    
    let linearFun (m : float) (n : float) (x : float) : float = x * m + n
    linearFun m n

let linearRegressionFunction = SLR countryData

let chart = Chart.Combine(
                 [Chart.Point ([for i in 0 .. (countryData |> Seq.length) - 1 -> Seq.item i countryData])
                  Chart.Line ([for x in 0 .. 100 -> x, linearRegressionFunction (float x)])]
                 ).WithTitle("gun ownership - homocide correlation")
                 .WithXAxis(MajorGrid=ChartTypes.Grid(Enabled=false), Title = "privatly owned guns per capita", Min = 0., Max = 110.)
                 .WithYAxis (MajorGrid=ChartTypes.Grid(Enabled=false), Title = "homocide rate", Min = 0., Max = 120.)                

System.Windows.Forms.Application.Run(chart.ShowChart())

System.Console.ReadKey() |> ignore