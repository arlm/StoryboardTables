StoryboardTables
================

Example project demonstrating a problem on Xamarin Studio

# How to reproduce

1. Compile using Xamarin Studio Stable or Beta
2. Debug the application on the Simulator
3. Debug the application on your iOS device
4. Open the `storyboard` file on XCode
5. Add a button and an outlet for it
6. Close XCode
7. Create a `TouchUpInside` event delegate that changes the text on any other component
8. Debug the application on the Simulator
9. Debug the application on your iOS device

# What is the problem

On the `Main.cs` file, when attaching the `AppDelegate`, the application throws an exception complaining that some outlet is not being found on the Dictionary.