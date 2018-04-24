open FSharp.Charting

let data : float list = [2. ; 2. ; 2. ; 3. ; 3. ; 3. ; 4. ; 4. ; 5. ; 5. ; 6. ; 6. ; 7. ; 7. ; 8.]

let rnd = new System.Random()

let threeSyntheticDataSets : (string * float list) list = 
    [ ("random 1" , [ for i in 0 .. 20 -> float (rnd.Next 20) ])
      ("random 2" , [ for i in 0 .. 200 -> float (rnd.Next 25) ])
      ("random 3" , [ for i in 0 .. 20 -> float (rnd.Next 25) ]) 
      ("manual input", data)
    ]

let chart : ChartTypes.GenericChart = Chart.BoxPlotFromData(
                                            threeSyntheticDataSets,
                                            ShowUnusualValues = true,
                                            ShowMedian = false ,
                                            ShowAverage = false
                                            ).WithXAxis(MajorGrid = ChartTypes.Grid (Enabled=false))

System.Windows.Forms.Application.Run(chart.ShowChart())