# Win10_BrightnessSlider
this app puts a Monitor Brightness icon to on Taskbar Tray. So you can access it with 1 click.

* **tested on** win10 build 10240 x64.
* **tags:** Windows 10 MONITOR Brightness Slider Icon on Taskbar Tray

**Download Link**  [Click Here To Download](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/Win10_BrightnessSlider/bin/Debug/Win10_BrightnessSlider.exe?raw=true)

#### Features

* Volume like Slider to Change Monitor Brightness
* Option to Run At Startup

#### ScreenShots

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss1.jpg?raw=true)

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss2.jpg?raw=true)

 
#### If you get error "Not Supported" 
1) paste this  windows powershell 
   
   $monitor = Get-WmiObject -ns root/wmi -class wmiMonitorBrightNessMethods$monitor.WmiSetBrightness(80,10) 
  
   if the code above gives error. then, there is nothing i can do . 
   because, WmiSetBrightness is provided by microsoft.  please dont open issue about this.
    
2) try install/update your graphic driver  

 
#### Fixed
slider will show at the nearest place to your taskbar  
