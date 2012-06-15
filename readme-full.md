![logo](https://bitbucket.org/christianspecht/missilesharp/raw/tip/img/logo128x128.png)

MissileSharp is a .NET library to control an USB Missile Launcher.

For now it supports only one model, the [Dream Cheeky Thunder](http://www.dreamcheeky.com/thunder-missile-launcher), as this is the only one I own.  
*(I'm in Germany, and I bought my missile launcher [from a German shop](http://www.getdigital.de/products/USB_Raketenwerfer)...but it seems to be the exact same model as the Dream Cheeky Thunder.)*

---

## Links

- [Main Project page on Bitbucket](https://bitbucket.org/christianspecht/missilesharp)
- [Download page](https://bitbucket.org/christianspecht/missilesharp/downloads)

---

## How to use

The main class of MissileSharp is the `CommandCenter` class. It has only one constructor, which expects a parameter of the type `ILauncherModel` - these are the different missile launcher models.  
*(As MissileSharp only supports one model at the moment, you can only pass a* `ThunderMissileLauncher` *for now)*

When you have created an instance of the `CommandCenter` class, you can use its methods to control the missile launcher.  
There are only three different types of commands:

1. Move (`Up` / `Down` / `Left` / `Right`)  
Move the launcher in the specified direction. One parameter to specify the duration in milliseconds.
2. `Reset`  
Reset the position (move to bottom left)
3. `Fire`  
Fire up to four missiles. One parameter to specify the number of shots.

MissileSharp comes with a demo console application - [see the code for a complete example](https://bitbucket.org/christianspecht/missilesharp/src/tip/src/MissileSharp.Demo/Program.cs).

---

## How to build

Run `build.bat` in the main folder. This will create a new folder named `release` with the compiled assembly.

---

### Acknowledgements

Thanks to [Chris Dance](https://github.com/codedance) for [the inspiration to this](https://github.com/codedance/Retaliation), especially his blog post [Who broke the build?](http://www.papercut.com/blog/chris/2011/08/19/who-broke-the-build/) which made me want to buy my own missile launcher and write a library for it.

MissileSharp makes use of the following open source projects:

- [Hid Library](https://github.com/mikeobrien/HidLibrary)
- [MSBuild Community Tasks](https://github.com/loresoft/msbuildtasks)
- [NuGet](http://nuget.codeplex.com/)

---

### License

MissileSharp is licensed under the MIT License. See [License.txt](https://bitbucket.org/christianspecht/missilesharp/raw/tip/License.txt) for details.