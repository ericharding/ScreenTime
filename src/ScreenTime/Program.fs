open System
open ScreenTimeQuery
open System.Net.Http

let client = new HttpClient()
let query = ScreenTimeQueryGraphqlClient("http://cerberus:5532/v1/graphql", client)

let doInsert title idleTime =
  let input : InsertScreenTime.InputVariables = {
    ForegroundTitle = Some title
    Host = Some Environment.MachineName
    IdleSeconds = Some (int idleTime)
    User = Some Environment.UserName
    Begin = Some DateTimeOffset.Now }
  query.InsertScreenTime input

// type InputVariables =
//     { ForegroundTitle: Option<string>
//       Host: Option<string>
//       IdleSeconds: Option<int>
//       User: Option<string>
//       Begin: Option<System.DateTimeOffset> }

let rec run wasIdle title =
  async {
    do! Async.Sleep 1000
    let idleTime = NativeMethods.idleTime()
    let isIdle = idleTime.TotalSeconds > 60.0
    let title' = if isIdle then title else NativeMethods.foregroundWindowTitle()
    if isIdle && not wasIdle then printfn "Idle..."
    if not isIdle && title <> title' then
      printfn "Looking at %s" title'
      doInsert title idleTime.TotalSeconds |> ignore
    do! run isIdle title'
  }

run false "" |> Async.RunSynchronously

// System.Environment.UserName
// System.Environment.MachineName