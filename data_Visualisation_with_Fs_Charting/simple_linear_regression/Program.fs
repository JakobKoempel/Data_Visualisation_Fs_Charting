open FSharp.Charting

let dataSet = [(1. , 2.) ; (1. , 4.) ; (2. , 5.) ; (3. , 5.) ; (3.3 , 5.5) ; (4. , 4.) ; (4.3, 5.3) ; (5. , 5.)]

let slr (s : (float * float) seq) : float -> float=
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

let linearRegressionFunction = slr dataSet

let chart = Chart.Combine(
               [ Chart.Line ([for x in 1. .. 5. -> x, linearRegressionFunction x])
                 Chart.Point ([for i in 0 .. dataSet.Length - 1 -> Seq.item i dataSet])]
               ).WithXAxis(Title = "X-Axis", Min = 0.0, Max = 6.0)
               .WithYAxis (Title = "Y-Axis", Min = 0.5)

System.Windows.Forms.Application.Run(chart.ShowChart())