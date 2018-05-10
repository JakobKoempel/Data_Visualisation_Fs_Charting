# Line charts with FsCharting

In this program, I created line charts in F# using the FsCharting library. Line Charts are created in a similar way as bar charts 
but several line charts can be combined into one diagram. In order to create a line chart with FsCharting, Chart.Line
has to be called. It takes one sequence of a numeric data types as an argument. 
Example:

```fsharp
open FSharp.Charting

let c = Chart.Line [for x in 1..10 -> x * x]

System.Windows.Forms.Application.Run(c.ShowChart())
```

We can make more line charts and combine hem into one by storing all of them into a list and use this list in the constructor
of Chart.Combine.

```fsharp
open FSharp.Charting

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
```
This is what the new combined line chart looks like:

![line chart](https://user-images.githubusercontent.com/38069530/39869863-8ebf67de-545f-11e8-89ac-c6fa79865f96.PNG)
