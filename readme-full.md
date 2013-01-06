![logo](https://bitbucket.org/christianspecht/missilesharp/raw/tip/img/logo128x128.png)

MissileSharp is a .NET library to control an USB Missile Launcher.

For now it supports only one model, the [Dream Cheeky Thunder](http://www.dreamcheeky.com/thunder-missile-launcher), as this is the only one I own.  
*(I'm in Germany, and I bought my missile launcher [from a German shop](http://www.getdigital.de/products/USB_Raketenwerfer)...but it seems to be the exact same model as the Dream Cheeky Thunder.)*

---

## Links

- [Download page](https://bitbucket.org/christianspecht/missilesharp/downloads)
- [NuGet gallery](https://nuget.org/packages/MissileSharp)
- [Found a bug?](https://bitbucket.org/christianspecht/missilesharp/issues/new)
- [Main project page on Bitbucket](https://bitbucket.org/christianspecht/missilesharp)

---

## Setup

You can either download MissileSharp from the download page on Bitbucket (link above) or install with [NuGet](https://nuget.org/):

[![NuGet](https://bitbucket.org/christianspecht/missilesharp/raw/tip/img/nuget.png)](https://nuget.org/packages/MissileSharp)

The control software that came with the missile launcher is not needed at all.  
Just connect the device to your machine, and Windows should automatically recognize it. That's enough for MissileSharp to control it.

---

## How to use

The main class of MissileSharp is the `CommandCenter` class.  
It has only one constructor, which expects a parameter of the type `ILauncherModel` - these are the settings for the different missile launcher models.  
*(As MissileSharp only supports one model at the moment, you can only pass a* `ThunderMissileLauncher` *for now)*

#### Simple example

    var launcher = new CommandCenter(new ThunderMissileLauncher());

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

#### Executing sequences of commands

Instead of directly calling the methods, you can also pass a complete sequence of commands at once as an `IEnumerable<LauncherCommand>`.  
A `LauncherCommand` consists of an [enum value](https://bitbucket.org/christianspecht/missilesharp/src/tip/src/MissileSharp/Command.cs) (e.g. `Command.Up` or `Command.Fire` - exactly the same commands as explained above) and a numeric parameter (for either the duration or the number of shots).

The following code does the same as the previous example, but creates and executes a `List<LauncherCommand>` instead of directly calling `Up`, `Fire` etc.:

	var commands = new List<LauncherCommand>();
	commands.Add(new LauncherCommand(Command.Reset, 0));
	commands.Add(new LauncherCommand(Command.Right, 1000));
	commands.Add(new LauncherCommand(Command.Up, 500));
	commands.Add(new LauncherCommand(Command.Fire, 2));

	launcher.RunCommandSet(commands);

#### Config files

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

If you want to see a complete example, there is a demo console application in the code (not in the releases).  
Look at [the code](https://bitbucket.org/christianspecht/missilesharp/src/tip/src/MissileSharp.Demo/Program.cs) and [the config file](https://bitbucket.org/christianspecht/missilesharp/src/tip/src/MissileSharp.Demo/settings.txt).

---

## How to build

Run `build.bat` in the main folder. This will create a new folder named `release` with the compiled assembly.  
Run `build-release.bat` to create a NuGet package and a zip file (all in the `release` folder) as well.

---

### Acknowledgements

Thanks to [Chris Dance](https://github.com/codedance) for [the inspiration to this](https://github.com/codedance/Retaliation), especially his blog post [Who broke the build?](http://www.papercut.com/blog/chris/2011/08/19/who-broke-the-build/) which made me want to buy my own missile launcher and write a library for it.

MissileSharp makes use of the following open source projects:

- [Autofac](http://autofac.org)
- [Hid Library](https://github.com/mikeobrien/HidLibrary)
- [MahApps.Metro](http://mahapps.com/MahApps.Metro/)
- [Modern UI Icons](http://modernuiicons.com/)
- [Moq](http://code.google.com/p/moq/)
- [MSBuild Community Tasks](https://github.com/loresoft/msbuildtasks)
- [NuGet](http://nuget.codeplex.com/)
- [NUnit](http://nunit.org/)

---

### License

MissileSharp is licensed under the MIT License. See [License.txt](https://bitbucket.org/christianspecht/missilesharp/raw/tip/License.txt) for details.