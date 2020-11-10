open System

let rec run wasIdle =
  async {
    do! Async.Sleep 1000
    let isIdle = NativeMethods.idleTime().TotalSeconds > 1.0
    if isIdle && not wasIdle then
      printfn "Idle"
    else if wasIdle && not isIdle then
      printfn "Awake!"
    do! run isIdle
  }

run false |> Async.RunSynchronously
