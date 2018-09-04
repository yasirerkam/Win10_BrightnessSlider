# Win10_BrightnessSlider
this app puts a Monitor Brightness icon to on Taskbar Tray. So you can access it with 1 click.
targeting laptops. 

if slider **doesnt work,** some ddci monitor need to  **rightClick Brightness icon>Press 'Detect monitor'**.

* **supported os**:  win7 , win8 , win10 
* **requirements**: .net4 framework.  (win7 may need to install)  
* **Note For Developers**: code version is  first working version (maybe 1.01). but **executable is always up to date**

**Donate Me:** [DonateMe](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/DonateMe.md)  

**Discord:** [Discord](https://discordapp.com/channels/484323520671907840) 

**Download Link**   [All Versions](https://github.com/blackholeearth/Win10_BrightnessSlider/releases)


#### Features

* Supports ddc/ci monitors
* Seperate Sliders For Multiple Monitors
* Volume like Slider to Change Monitor Brightness
* Option to Run At Startup
* Ability to *"Rescan/Detect Monitor"* after a Monitor Plugged in/out

#### ScreenShots

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss1.jpg?raw=true)

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss2.jpg?raw=true)

![alt text](https://github.com/blackholeearth/Win10_BrightnessSlider/blob/master/ss3.jpg?raw=true)


 
#### If you get error "Not Supported"  ( fixed at v1.04)
#####  this means WMI method not supported.  it will try to use  ddc/ci  if its enabled at monitor menu 

1) paste this  windows powershell 
   
   $monitor = Get-WmiObject -ns root/wmi -class wmiMonitorBrightNessMethods$monitor.WmiSetBrightness(80,10) 
  
   if the code above gives error. then, there is nothing i can do . 
   because, WmiSetBrightness is provided by microsoft.  please dont open issue about this.
    
2) try install/update your graphic driver  

 
#### ChangeLog

v1.7.3
 * added:  if there is new version, shows in rightclick menu.
 * fixing: new monitor populator
 
v1.7.1
* fixed: ddci brightness displaying -1 (may not work on all ddci monitors)
* fixed: blurry text high dpi  

v1.6
* fixed: issue: ``i got 3 screens, but i have 5 sliders``. (slider popualtion method changed )
 
v1.04 
* added: author page to  menu item  that shows version no.
* trying to fix: fallback doesnt handle management not supported exception.

v1.02

* added: seperately change brightness of multiple monitors.
* added: supports setting Brighness on ddc/ci Monitors(at startup, it may show -1,  )
* fixed: slider showing itself on second screen onhide 
* fixed: popup stays under taskbar, if taskbar is autoHiding  

v1.01

* fixed: slider wasn't positioning itself according to taskbar position (Top Or Bottom Or Left Or Right of Screen)

