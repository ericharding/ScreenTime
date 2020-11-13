namespace ScreenTimeQuery

open Fable.Remoting.Json
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open System.Net.Http
open System.Text

type GraphqlInput<'T> = { query: string; variables: Option<'T> }
type GraphqlSuccessResponse<'T> = { data: 'T }
type GraphqlErrorResponse = { errors: ErrorType list }

type ScreenTimeQueryGraphqlClient(url: string, httpClient: HttpClient) =
    let converter = FableJsonConverter() :> JsonConverter
    let settings = JsonSerializerSettings(DateParseHandling=DateParseHandling.None, Converters = [| converter |])

    new(url: string) = ScreenTimeQueryGraphqlClient(url, new HttpClient())

    member _.InsertScreenTimeAsync(input: InsertScreenTime.InputVariables) =
        async {
            let query = """
                
                mutation InsertScreenTime($ForegroundTitle: String, $Host: String, $IdleSeconds: Int = 10, $User: String = "", $Begin: timestamptz = "1970-01-1T0:30:00+05:00") {
                  insert_Home_ScreenTime(objects: {ForegroundTitle: $ForegroundTitle, Host: $Host, IdleSeconds: $IdleSeconds, User: $User, Begin: $Begin}) {
                    affected_rows
                  }
                }
            """

            let inputJson = JsonConvert.SerializeObject({ query = query; variables = Some input }, [| converter |])

            let! response =
                httpClient.PostAsync(url, new StringContent(inputJson, Encoding.UTF8, "application/json"))
                |> Async.AwaitTask

            let! responseContent = Async.AwaitTask(response.Content.ReadAsStringAsync())
            let responseJson = JsonConvert.DeserializeObject<JObject>(responseContent, settings)

            match response.IsSuccessStatusCode with
            | true ->
                let errorsReturned =
                    responseJson.ContainsKey "errors"
                    && responseJson.["errors"].Type = JTokenType.Array
                    && responseJson.["errors"].HasValues

                if errorsReturned then
                    let response = responseJson.ToObject<GraphqlErrorResponse>(JsonSerializer.Create(settings))
                    return Error response.errors
                else
                    let response = responseJson.ToObject<GraphqlSuccessResponse<InsertScreenTime.Query>>(JsonSerializer.Create(settings))
                    return Ok response.data

            | errorStatus ->
                let response = responseJson.ToObject<GraphqlErrorResponse>(JsonSerializer.Create(settings))
                return Error response.errors
        }

    member this.InsertScreenTime(input: InsertScreenTime.InputVariables) = Async.RunSynchronously(this.InsertScreenTimeAsync input)
