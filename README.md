# Exercises for F#

### Configure Execism download location
```
exercism configure --workspace C:\Users\william\Projects\exercism-fsharp
```

### Add all projects to solution
This should be run periodically

```
dotnet sln add (ls -r **/*.fsproj)
```