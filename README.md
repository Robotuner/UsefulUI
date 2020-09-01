# UsefulUI
ESI Useful UI Demo

UsefulUI is a set of Xamarin Forms controls for Android and iOS that I created for mundane line of business type data entry on mobile devices.  Its main goal is to minimize XAML redundancy.
Most of the control are composite Xamarin forms controls packaged together.  For example, it is common to use an entry control to allow the user to enter data, but the reality 
that to support that control, applications also need a title Label control that describes what is expected in the control. In many cases the application has two use cases, one
to show the data the other to collect the data.  Also in some cases, when the entry control is enabled it is a required data field.

For DateTime, line of business application will need both a date and a time, sometimes when a picker is available, it is required, others it might not be.  If the underlying
DateTime control is nullable, . . . some mechanism must be provided for entering a null Date Time.

Some of the composite controls are:
Label
Entry
Editor
Date and Time
Search
Multi-Column Grid
Calendar

# Documentation
Please look at the website for a complete description.  https://www.engenious.com/UsefulUI/Intro.html

# Supported Platforms
Android and iOS, there are no plans to support UWP.

# Initial Release Versions
Initial release Version 16.7.0. 
.Net Framework 4.8.04752
Xamarin 16.7
Xamarin Android SDK 11.0
Xamarin.iOS and Xamarin.Mac SDK 13.20.2.2
