namespace ci.BuildOutput

open Common.ConsoleUtil

type BuildStatus = | Building | BuildFailed | BuildSucceeded

type OutputDataHandler() =
    let mutable buildStatus = Building
    member x.handle (data: string) = 
        match buildStatus with
        | Building -> 
            if data.Contains("Build succeeded") then buildStatus <- BuildSucceeded
            else if data.Contains("Build FAILED") then buildStatus <- BuildFailed
        | BuildFailed -> writelineRed data
        | BuildSucceeded -> writelinePurple data 
