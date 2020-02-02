module Clock

type Clock = {
    Hours: int
    Minutes: int
}

let minutesInAnHour = 60
let hoursInADay = 24
let minutesInADay = minutesInAnHour * hoursInADay

let getTimeInMinutes hours minutes = 
    (hours * minutesInAnHour) + minutes

let create hours minutes = 

    let timeInMinutes = getTimeInMinutes hours minutes
    
    let minute =
        if minutes % minutesInAnHour < 0
            then (minutes % minutesInAnHour) + minutesInAnHour
        else minutes % minutesInAnHour

    let hour =
        let hours =
            if timeInMinutes % minutesInAnHour < 0 then
                timeInMinutes / minutesInAnHour - 1
            else timeInMinutes / minutesInAnHour

        let hoursInRange = hours % hoursInADay
        if hoursInRange < 0 then hoursInRange + hoursInADay
        else hoursInRange

    { Hours = hour; Minutes = minute }   

let add minutes clock = 
    let timeInMinutes = getTimeInMinutes clock.Hours clock.Minutes
    create 0 (timeInMinutes+minutes)

let subtract minutes clock =
    add (-minutes) clock

let display clock = 
    sprintf "%02i:%02i" clock.Hours clock.Minutes