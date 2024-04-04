// Define discriminated union for movie genres
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define record type for Director
type Director = { Name: string; Movies: int }

// Define record type for Movie
type Movie = { 
    Name: string; 
    RunTime: int; // in minutes
    Genre: Genre; 
    Director: Director; 
    IMDBRating: float 
}

// Create movie instances
let coda = { Name = "CODA"; RunTime = 111; Genre = Drama; Director = { Name = "Sian Hader"; Movies = 9 }; IMDBRating = 8.1 }
let belfast = { Name = "Belfast"; RunTime = 98; Genre = Comedy; Director = { Name = "Kenneth Branagh"; Movies = 23 }; IMDBRating = 7.3 }
let dontLookUp = { Name = "Don't Look Up"; RunTime = 138; Genre = Comedy; Director = { Name = "Adam McKay"; Movies = 27 }; IMDBRating = 7.2 }
let driveMyCar = { Name = "Drive My Car"; RunTime = 179; Genre = Drama; Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }; IMDBRating = 7.6 }
let dune = { Name = "Dune"; RunTime = 155; Genre = Fantasy; Director = { Name = "Denis Villeneuve"; Movies = 24 }; IMDBRating = 8.1 }
let kingRichard = { Name = "King Richard"; RunTime = 144; Genre = Sport; Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }; IMDBRating = 7.5 }
let licoricePizza = { Name = "Licorice Pizza"; RunTime = 133; Genre = Comedy; Director = { Name = "Paul Thomas Anderson"; Movies = 49 }; IMDBRating = 7.4 }
let nightmareAlley = { Name = "Nightmare Alley"; RunTime = 150; Genre = Thriller; Director = { Name = "Guillermo Del Toro"; Movies = 22 }; IMDBRating = 7.1 }

// Create a list of movies
let movies = [coda; belfast; dontLookUp; driveMyCar; dune; kingRichard; licoricePizza; nightmareAlley]

// Identify probable Oscar winners (IMDB rating greater than 7.4)
let probableOscarWinners = List.filter (fun movie -> movie.IMDBRating > 7.4) movies

// Convert movie run length to hours and minutes format
let convertRunTime (runtime: int) =
    let hours = runtime / 60
    let minutes = runtime % 60
    sprintf "%dh %dmin" hours minutes

// Create a list of tuples containing movie name and converted run time
let movieRunTimes = List.map (fun movie -> (movie.Name, convertRunTime movie.RunTime)) movies

// Display results
printfn "Probable Oscar Winners:"
probableOscarWinners |> List.iter (fun movie -> printfn "- %s" movie.Name)

printfn "\nMovie Run Times:"
movieRunTimes |> List.iter (fun (name, runtime) -> printfn "- %s: %s" name runtime)
