# Unity-Job-Search (TBD)

A VR Application in Unity that captures a series of locations and experiences that reflect the job search process at the University of South Carolina. A Beta release apk file can be found in the "releases" tab.

# Installation for development
## Prerequisites
* Clone Unity Job Search Repository
* Download [Latest Version of Unity](https://unity3d.com/get-unity/download)
* Download [Android Studio](https://developer.android.com/studio/) <br/>
When installing Unity, make sure `Android Build Support` is selected.

### Setup Android Studio
* Open Android Studio and click `Configure` at the bottom right and select `SDK Manager`.
* Under `SDK Platforms`, make sure to check and install `API Level` 21 - 28 or from Android 5.0 up to the latest. (Currently 7) and click Apply. Installation can take up to several hours.

* Move over to `SDK Tools` and select `Show Package Details` and install 28.0.2 or the latest. 
* Make sure under `LLDB` latest version is installed.
* Install `Android SDK Platform-Tools`, `Android SDK Tools` and `NDK`
* After installation, go back to `Configure` Menu and select `Project Defaults` then `Project Structure`
* Save the location directory of `Android SDK location`, `JDK location`, and `Android NDK location` for later use. (Notepad)
* Setting `Environment Variables`. On Windows machine, search for “Environment Variables”. This should take you to Control Panel > System Properties, Go to the Advanced Tab, then to the Environment Variables button in the lower right.
* In the top section, set/modify/add the following variables:
* `Set the environment variable JAVA_HOME to the JDK location`
* `Set the environment variable ANDROID_HOME to the Android SDK location.`
* `Set the environment variable ANDROID_NDK_HOME to the Android NDK location.`
* `Add the JDK tools directory to your PATH, ie C:\Program Files\Android Studio\jre\bin`

### Setup Unity to Build for Android
* Go to **File > Build Settings**
* Select Android and then **Switch Platform.** (If you did not add Android support when you first installed Unity, you will have to do so now, then restart Unity).
* Close out and go to **Edit > Preferences** then **External Tools** Tab
** Scroll down to Android section and set `SDK, JDK, NDK` paths from earlier ten close
* Now go to **Edit > Project Settings > Player**
* Scroll to **XR Settings** and choose **Oculus** within the **Virtual Reality SDKs** box (Make sure **Virtual Reality SDK** is ticked)

### Setup Android Debug Bridge
**This step is required to get the app onto the GO

* Download and install the [Occulus Go ADB Driver](https://developer.oculus.com/downloads/package/oculus-go-adb-drivers/)
* Unzip the file and Right click on the **.inf file** and **install.

### Connecting your Go to Build
* Connect Go to PC via USB
* Run `adb devices` to make sure your Go has been connected.
* In Unity, go to **File > Build Settings** and Build your scenes
* Save your APK somewhere for your builds and copy that build to where you installed the ADB from last step
* then **Run** `adb install [buildname].apk
* After you see, **SUCCESS** on the screen, that means it has downloaded to your GO.
* Inside your GO, Go to **Library > Unknown Sources** and you should see your Built app there.

### More In-Dept Guide if needed
[Build on Unity with Go Video](https://www.youtube.com/watch?v=LSypZfOChYE)
[Article on how to build](https://www.youtube.com/watch?v=LSypZfOChYE)

### Unit and Behaviour Testings
* Currently Unity Test Runner doesn't seem to have much support for VR/Oculus Go testings.. so we tried it without the controller and VR setups.
* The tests are located under Assets/Tests directory.
* Current test are scene switching when button is clicked and check whether the door is opened or closed. 
* All tests are done through the built-in Unity Test Runner. 
* To access Unity Test Runner, go to Window > General > Test Runner, then select Play Mode then Run All.
* [More information on Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html)
https://streamable.com/r1hw8
