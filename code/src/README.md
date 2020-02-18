## Project Build

Best way to build the whole project is to use _Visual Studio 2017 Community_. Thereafter, download the 
complete sources, open the solution file `Plexdata.Dialogs.sln`, switch to release and rebuild all.

- The dialogs library is a _.NET Framework 4.8_ project for WPF applications.
- The tester application is a WPF project using _.NET Framework 4.8_.

## Help Generation

The help file with the whole API documentation is not yet available.

## Breaking Changes

Nothing known at the moment.

## Trouble Shooting

Nothing known at the moment.

## Known Issues

Under some circumstances the `ExceptionBox` scrolls its content in an unusual behavior. The reason 
behind, the base tree view scrolls their selected items "into view" with the effect that the current 
selection "jumps". At the moment, there is no way know to fix this behavior. Another issue is the fact 
that scrolling down brings the header out of view. These issues might be fixed in a later version.

Under some circumstances the `OpenFolderDialog` hangs when huge directory (e.g. `C:\Windows`) is going 
to open. And unfortunately no idea why, at the moment.
