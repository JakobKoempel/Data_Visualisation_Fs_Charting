# Bar charts in F#

In this project I created a bar chart in F# using FsCharting.

```fsharp
open FSharp.Charting

let countryData1 = 
    [ "Africa", 1_126_396_209L; 
      "Asia", 4_436_285_301L; 
      "Europe", 741_461_395L; 
      "South America", 425_849_627L; 
      "North America", 579_461_659L; 
      "Australia \nOceania", 25_305_783L]

let countryData2 =
    [ "Antarctica", 2000L]

let chart = Chart.Bar (countryData1 @ countryData2 |> Seq.sortByDescending (fun (_, y) -> y), 
                       Name = "Population by Continent")

System.Windows.Forms.Application.Run(chart.ShowChart())
```

A bar chart can be created in the following two lines.

````fsharp
let chart = Chart.Bar (exampleSequence)
System.Windows.Forms.Application.Run(chart.ShowChart())
```
(Note: exampleSequence : (string * int64) list)

Now, I create data stored in sequences of tuples, connect them, sort them by the int64 value and create a bar chart out of them. The 
strings in the tuple are used as labels for the single bars.  
Furthermore, we can label the whole bar chart by adding one more argument 
to the constructor.

```fsharp
let chart = Chart.Bar (countryData1 @ countryData2 |> Seq.sortByDescending (fun (_, y) -> y), 
                       Name = "Population by Continent")
```
