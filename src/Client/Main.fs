module Client.Main

open Elmish
open Bolero
open Bolero.Html

type Model =
    {
        value: int
    }

let initModel =
    {
        value = 0
    }

type Message =
    | Increment
    | Decrement

let update message model =
    match message with
    | Increment -> { model with value = model.value + 1 }
    | Decrement -> { model with value = model.value - 1 }

let view model dispatch =
    concat [
        button [on.click (fun _ -> dispatch Decrement)] [text "-"]
        span [] [text (" " + string model.value + " ")]
        button [on.click (fun _ -> dispatch Increment)] [text "+"]
    ]

type MyApp() =
    inherit ElmishProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
