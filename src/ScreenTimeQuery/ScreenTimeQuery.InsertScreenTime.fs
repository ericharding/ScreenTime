[<RequireQualifiedAccess>]
module rec ScreenTimeQuery.InsertScreenTime

type InputVariables =
    { ForegroundTitle: Option<string>
      Host: Option<string>
      IdleSeconds: Option<int>
      User: Option<string>
      Begin: Option<System.DateTimeOffset>
      End: Option<System.DateTimeOffset> }

/// insert data into the table: "Home.ScreenTime"
type Home_ScreenTime_mutation_response =
    { /// number of affected rows by the mutation
      affected_rows: int }

/// mutation root
type Query =
    { /// insert data into the table: "Home.ScreenTime"
      insert_Home_ScreenTime: Option<Home_ScreenTime_mutation_response> }
