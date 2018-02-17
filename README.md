# RemoteDesktopManager
RemoteDesktopManager is an Open Source Multi RDP Client written in C#.NET.

# What you need
- Microsoft Visual Studio 2017 (15.5)
- .NET Framework 4.6.2
- Microsoft RDP Control Version 10 (Check, if your Windows has this COM-Control. If not, then follow the instructions in Section "The RDP-Control Version isn't available")

# How to build
Open the RemoteDesktopManager.sln in Microsoft Visual Studio and build it.

# Future Plans
- Better Design for the GUI
- Multi-Language-Framework for the GUI
- Read RDP-Files
- Export Connections as RDP-File
- Bind Events in Code
- and much more...

# Next Updates
- Remove all RemoteDesktopData-Objects and code from the project
- Clean Using-Directives
- Bind Events in Code
- Database-Updater, so the program add the new columns automatically

# The RDP-Control Version isn't available
This can be happen, if you don't have the latest version of Windows 10. If you want to build with a lower version of the Microsoft RDP Control, follow these steps:
1. Select from the COM-Components the Microsoft RDP Control with the highest version, which is available.
2. Add this on the form "RemoteDesktopTabPageView" 
3. Change Dock to "Fill" and set the name to "rdp".
4. Connect the existing event methods with the events. If you want to know, which events it concerns, then watch at https://github.com/ChaosEmerald95/RemoteDesktopManager/blob/master/RemoteDesktopManager/RemoteDesktopTabPageView.Designer.cs
