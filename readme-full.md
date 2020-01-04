![logo](https://raw.githubusercontent.com/christianspecht/missilesharp/master/img/logo128x128.png)

MissileSharp is a .NET library to control an USB Missile Launcher.  
*(There is also a demo app called the [MissileSharp Launcher](https://christianspecht.de/missilesharp/#launcher))*

For now it supports only one model, the [Dream Cheeky Thunder](http://www.dreamcheeky.com/thunder-missile-launcher), as this is the only one I own.  
*(I'm in Germany, and I bought my missile launcher [from a German shop](http://www.getdigital.de/products/USB_Raketenwerfer)...but it seems to be the exact same model as the Dream Cheeky Thunder.)*

---

## Links

- [Download page](https://github.com/christianspecht/missilesharp/releases) *(MissileSharp and MissileSharp Launcher)*
    - [Install MissileSharp via NuGet](https://nuget.org/packages/MissileSharp)
- [Report a bug](https://github.com/christianspecht/missilesharp/issues/new)
- [Main project page on GitHub](https://github.com/christianspecht/missilesharp)

---

## Setup

You can either download MissileSharp from the download page on GitHub (link above) or install with [NuGet](https://nuget.org/):

[![NuGet](https://raw.githubusercontent.com/christianspecht/missilesharp/master/img/nuget.png)](https://nuget.org/packages/MissileSharp)

The control software that came with the missile launcher is not needed at all.  
Just connect the device to your machine, and Windows should automatically recognize it. That's enough for MissileSharp to control it.

---

## How to use

The main class of MissileSharp is the `CommandCenter` class.  
It has only one constructor, which expects a parameter of the type `ILauncherModel` - these are the settings for the different missile launcher models.  
*(As MissileSharp only supports one model at the moment, you can only pass a* `ThunderMissileLauncher` *for now)*

### Simple example

Create a new `CommandCenter` instance:

    var launcher = new CommandCenter(new ThunderMissileLauncher());

You can also use the `LauncherModelFactory` if you don't want to create an instance of the `ThunderMissileLauncher` class directly, e.g. to get the model from a config file:

	var launcherModel = LauncherModelFactory.GetLauncher("MissileSharp.ThunderMissileLauncher");
	var launcher = new CommandCenter(launcherModel);

Then, you can start sending commands to the device.  
There are three different types of commands:

1. Move (`Up`, `Down`, `Left`, `Right`)  
Move the launcher in the specified direction
2. `Reset`  
Reset to known position (move to bottom left)
3. `Fire`  
Fire some missiles

You can use these commands as methods of the `CommandCenter` class:
	
	launcher.Reset();   	// reset to bottom left
	launcher.Right(1000);   // turn right 1000 milliseconds
	launcher.Up(500);   	// move up 500 milliseconds
	launcher.Fire(2);		// fire 2 missiles

This is also available as a fluent interface:

    launcher.Reset().Right(1000).Up(500).Fire(2);

### Executing sequences of commands

Instead of directly calling the methods, you can also pass a complete sequence of commands at once as an `IEnumerable<LauncherCommand>`.  
A `LauncherCommand` consists of an [enum value](https://github.com/christianspecht/missilesharp/blob/master/src/MissileSharp/Command.cs) (e.g. `Command.Up` or `Command.Fire` - exactly the same commands as explained above) and a numeric parameter (for either the duration or the number of shots).

The following code does the same as the previous example, but creates and executes a `List<LauncherCommand>` instead of directly calling `Up`, `Fire` etc.:

	var commands = new List<LauncherCommand>();
	commands.Add(new LauncherCommand(Command.Reset, 0));
	commands.Add(new LauncherCommand(Command.Right, 1000));
	commands.Add(new LauncherCommand(Command.Up, 500));
	commands.Add(new LauncherCommand(Command.Fire, 2));

	launcher.RunCommandSet(commands);

### Config files

MissileSharp supports loading command sets from a config file as well.  
A config file with the commands from the examples above would look like this:
	
	[Steve]
	reset,0
	right,1000
	up,500
	fire,2

You can save several of these command sets in the same file, each one under its own name (in this case, "Steve").  
Lines beginning with `#` will be ignored and can be used for comments.

First, you have to load the file once:

	launcher.LoadCommandSets("settings.txt");

After that, you can execute any of the command sets by referring to the name:
	
	launcher.RunCommandSet("Steve");   // shoot Steve

If you want to see a simple but complete example, there is a demo console application in the code (not in the releases).  
Look at [the code](https://github.com/christianspecht/missilesharp/blob/master/src/MissileSharp.Demo/Program.cs) and [the config file](https://github.com/christianspecht/missilesharp/blob/master/src/MissileSharp.Demo/settings.txt).

For a more complex demo application, take a look at the MissileSharp Launcher:

---

<a name="launcher"></a>
## MissileSharp Launcher

MissileSharp Launcher is a WPF application, which uses MissileSharp to do exactly what is described in the "Config files" section above:  
On startup, it automatically loads command sets from a settings file and displays a button for each available command set. You can run the command sets by clicking the respective button.

Using the [config file](https://github.com/christianspecht/missilesharp/blob/master/src/MissileSharp.Demo/settings.txt) from the previous example, it looks like this:

![MissileSharp Launcher screenshot](https://raw.githubusercontent.com/christianspecht/missilesharp/master/img/launcher.png)

You can edit the settings file at runtime with these two buttons:  
![Edit Settings](https://raw.githubusercontent.com/christianspecht/missilesharp/master/img/launcher-settings.png)  
The left one opens the settings file for editing.  
After editing, click the right button to re-load the settings from the file.

### How to get MissileSharp Launcher:

[Download a zip file with the binaries](https://github.com/christianspecht/missilesharp/releases)

At the moment, MissileSharp Launcher always uses the Thunder Missile Launcher model (hardcoded in `app.config`), but that will be changed when MissileSharp supports more than one model.

---

## How to build

Run `build.bat` in the main folder. This will create a new folder named `release` with the compiled assembly.  
Run `build-release.bat` to create a NuGet package and a zip file (all in the `release` folder) as well.

---

### Acknowledgements

Thanks to [Chris Dance](https://github.com/codedance) for [the inspiration to this](https://github.com/codedance/Retaliation), especially his blog post [Who broke the build?](https://blog.papercut.com/who-broke-the-build/) which made me want to buy my own missile launcher and write a library for it.

MissileSharp makes use of the following open source projects:

- [Autofac](https://autofac.org)
- [Hid Library](https://github.com/mikeobrien/HidLibrary)
- [MahApps.Metro](https://mahapps.com/)
- [Modern UI Icons](http://modernuiicons.com/)
- [Moq](https://github.com/Moq/moq4/)
- [MSBuild Community Tasks](https://github.com/loresoft/msbuildtasks)
- [NuGet](https://www.nuget.org/)
- [NUnit](https://nunit.org/)

---

<div id="license"></div>
### License

MissileSharp is licensed under the MIT License. See [License.txt](https://raw.githubusercontent.com/christianspecht/missilesharp/master/License.txt) for details.

---

### Project Info

<script type='text/javascript' src='https://www.openhub.net/p/missilesharp/widgets/project_basic_stats?format=js'></script>
<script type='text/javascript' src='https://www.openhub.net/p/missilesharp/widgets/project_languages?format=js'></script>

